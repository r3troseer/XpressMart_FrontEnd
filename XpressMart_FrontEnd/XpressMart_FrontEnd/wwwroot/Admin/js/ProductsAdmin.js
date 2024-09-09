window.DataTableInterop = {
    initializeDataTable: function (dotNetHelper) {
        var selectedProducts = [];
        $.fn.dataTable.ext.errMode = 'none';
        var table = $('#product-table').DataTable({
            serverSide: true,
            ajax: {
                url: 'http://localhost:5041/api/Products/table',
                contentType: 'application/json',
                type: "POST",
                data: function (d) {
                    return JSON.stringify({
                        draw: d.draw,
                        start: d.start,
                        length: d.length,
                        search: d.search.value,
                        order: d.order && d.order.length > 0
                            ? { column: d.columns[d.order[0].column].data, dir: d.order[0].dir }
                            : { column: 'id', dir: 'asc' }
                    });
                },
                dataSrc: {
                    data: 'data.products',
                    draw: 'data.draw',
                    recordsTotal: 'data.recordsTotal',
                    recordsFiltered: 'data.recordsFiltered'
                },
                error: function (xhr, error, thrown) {
                    console.error('DataTables Error:', error, thrown);
                    console.log(xhr.responseText);
                }
            },
            layout: {
                top1Start: {
                    buttons: [
                        {
                            text: 'Add Products',
                            action: function () {
                                dotNetHelper.invokeMethodAsync('AddProducts');
                            }
                        }
                    ]
                },
                top1End: 'buttons',
                topStart: 'pageLength',
                topEnd: 'search',
                bottomStart: 'info',
                bottomEnd: 'paging'
            },

            buttons: [
                'copy', 'excel', 'pdf', 'print',
                {
                    text: 'Activate',
                    action: function () {
                        selectedProducts = getSelectedProducts(table);
                        if (selectedProducts.length > 0) {
                            showConfirmationModal('activate');
                        } else {
                            toastr.warning('No products selected');
                        }
                    }
                },
                {
                    text: 'Deactivate',
                    action: function () {
                        selectedProducts = getSelectedProducts(table);
                        if (selectedProducts.length > 0) {
                            showConfirmationModal('deactivate');
                        } else {
                            toastr.warning('No products selected');
                        }
                    }
                },
                {
                    text: 'Delete',
                    action: function () {
                        selectedProducts = getSelectedProducts(table);
                        if (selectedProducts.length > 0) {
                            showConfirmationModal('delete');
                        } else {
                            toastr.warning('No products selected');
                        }
                    }
                }
            ],

            columns: [
                {
                    data: null,
                    defaultContent: '',
                    orderable: false,
                    className: 'select-checkbox',
                    checkboxes: {
                        selectRow: true
                    }
                },
                { data: 'id' },
                {
                    data: 'name',
                    name: 'name',
                    orderable: true,
                    render: function (data, type, row) {
                        if (row.mainImageUrl) {
                            return `
                                <a href="/products/${row.id}" class="d-flex align-items-center">
                                    <img src="${row.mainImageUrl}" alt="${row.name}" style="width: 50px; height: auto; margin-right: 10px; border-radius: 5px; object-fit: cover;">
                                    ${data}
                                </a>
                            `;
                        } else {
                            return `
                                <a href="/products/${row.id}" class="d-flex align-items-center">
                                    <div id="image-container-${row.id}" style="width: 50px; height: 50px; margin-right: 10px; border-radius: 5px; display: flex; align-items: center; justify-content: center; background-color: #f0f0f0;">
                                        <span id="image-status-${row.id}">Loading...</span>
                                    </div>
                                    ${data}
                                </a>
                            `;
                        }
                    }
                },
                { data: 'category.name' },
                { data: 'price' },
                {
                    data: null,
                    orderable: false,
                    render: function (data, type, row) {
                        return '<i class="fa fa-edit edit-icon" style="margin-right:10px;"></i>' +
                            '<i class="fa fa-trash delete-icon"></i>';
                    }
                }
            ],

            order: {
                name: "name",
                dir: "asc"
            },
            select: {
                style: 'multi',
                selector: 'td:first-child'
            },

            language: {
                lengthMenu: 'Display _MENU_ products',
                info: "Showing products _START_ to _END_ of _TOTAL_",
            }
        });

        // Handle "Select All" checkbox
        $('#select-all-checkbox').on('click', function () {
            if (this.checked) {
                table.rows().select();
            } else {
                table.rows().deselect();
            }
        });

        // Update "Select All" checkbox state
        table.on('select deselect', function () {
            var allSelected = table.rows({ selected: true }).count() === table.rows().count();
            $('#select-all-checkbox').prop('checked', allSelected);
        });

        $('#product-table tbody').on('click', 'i.view-icon', function () {
            var data = table.row($(this).parents('tr')).data();
            toastr.success('Viewing details for product ID: ' + data.id);
        });

        $('#product-table tbody').on('click', 'i.edit-icon', function () {
            var data = table.row($(this).parents('tr')).data();
            dotNetHelper.invokeMethodAsync('EditProduct', data.id);
        });

        $('#product-table tbody').on('click', 'i.delete-icon', function () {
            var data = table.row($(this).parents('tr')).data();
            selectedProducts = [data.id];
            showConfirmationModal('delete');
        });

        function getSelectedProducts() {
            return table.rows({ selected: true }).data().map(function (item) {
                return item.id;
            }).toArray();
        }

        function showConfirmationModal(action) {
            $('#confirmationModal').modal('show');
            $('#confirmationModalAction').val(action);
        }

        function loadProductImages() {
            var table = $('#product-table').DataTable();
            var visibleRows = table.rows({ page: 'current' }).data();

            visibleRows.each(function (rowData) {
                if (!rowData.mainImageUrl) {
                    checkImageStatus(rowData);
                }
            });
        }

        function checkImageStatus(rowData) {
            dotNetHelper.invokeMethodAsync('GetImageLoadingStatus', rowData.id)
                .then(function (status) {
                    updateImageStatus(rowData, status);
                })
                .catch(function (error) {
                    console.error('Error checking image status:', error);
                });
        }

        function updateImageStatus(rowData, status) {
            var statusElement = $(`#image-status-${rowData.id}`);
            switch (status) {
                case 'not_started':
                    statusElement.text('Initiating...');
                    dotNetHelper.invokeMethodAsync('InitiateImageLoad', rowData.id, rowData.mainImageFileId, rowData.mainImageDetail?.fileString);
                    break;
                case 'loading':
                    statusElement.text('Loading...');
                    setTimeout(function () { checkImageStatus(rowData); }, 1000);
                    break;
                case 'error':
                    dotNetHelper.invokeMethodAsync('GetImageLoadingError', rowData.id)
                        .then(function (error) {
                            statusElement.text('Error: ' + error);
                        });
                    break;
                case 'loaded':
                    if (rowData.mainImageDetail?.fileString) {
                        var imgElement = $('<img>')
                            .attr('src', 'data:image/jpeg;base64,' + rowData.mainImageDetail.fileString)
                            .attr('alt', rowData.name)
                            .css({
                                'width': '50px',
                                'height': 'auto',
                                'border-radius': '5px',
                                'object-fit': 'cover'
                            });
                        $(`#image-container-${rowData.id}`).empty().append(imgElement);
                    } else {
                        statusElement.text('No image');
                    }
                    break;
                default:
                    statusElement.text('Unknown status');
            }
        }

        loadProductImages();

        table.on('draw', function () {
            loadProductImages();
        });
    },

    onConfirm: function (dotNetHelper, action) {
        if (action === 'activate' || action === 'deactivate') {
            var isActive = action === 'activate';
            dotNetHelper.invokeMethodAsync('ChangeProductStatus', selectedProducts, isActive)
                .then(function () {
                    toastr.success('Products ' + (isActive ? 'activated' : 'deactivated') + ' successfully');
                    $('#product-table').DataTable().ajax.reload();
                })
                .catch(function (error) {
                    toastr.error('Failed to ' + action + ' products: ' + error);
                });
        } else if (action === 'delete') {
            selectedProducts.forEach(function (id) {
                dotNetHelper.invokeMethodAsync('DeleteProduct', id)
                    .then(function () {
                        toastr.success('Product deleted successfully');
                        $('#product-table').DataTable().ajax.reload();
                    })
                    .catch(function (error) {
                        toastr.error('Failed to delete product: ' + error);
                    });
            });
        }
    }
};