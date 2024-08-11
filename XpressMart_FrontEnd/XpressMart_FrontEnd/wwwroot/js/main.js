
(function ($) {
	"use strict"

	// Mobile Nav toggle
	if ($('.menu-toggle > a').length) {
		$('.menu-toggle > a').on('click', function (e) {
			e.preventDefault();
			$('#responsive-nav').toggleClass('active');
		});
	}

	// Fix cart dropdown from closing
	if ($('.cart-dropdown').length) {
		$('.cart-dropdown').on('click', function (e) {
			e.stopPropagation();
		});
	}

	/////////////////////////////////////////

	// Products Slick
	window.initializeProductsSlick = function () {
		if ($('.products-slick').length) {
			$('.products-slick').each(function () {
				var $this = $(this),
					$nav = $this.attr('data-nav');

				$this.slick({
					slidesToShow: 4,
					slidesToScroll: 1,
					autoplay: true,
					infinite: true,
					speed: 300,
					dots: false,
					arrows: true,
					appendArrows: $nav ? $nav : false,
					responsive: [{
						breakpoint: 991,
						settings: {
							slidesToShow: 2,
							slidesToScroll: 1,
						}
					},
					{
						breakpoint: 480,
						settings: {
							slidesToShow: 1,
							slidesToScroll: 1,
						}
					}]
				});
			});
		}
	};

	// Products Widget Slick
	window.initializeProductWidgetSlick = function () {
		if ($('.products-widget-slick').length) {
			$('.products-widget-slick').each(function () {
				var $this = $(this),
					$nav = $this.attr('data-nav');

				$this.slick({
					infinite: true,
					autoplay: true,
					speed: 300,
					dots: false,
					arrows: true,
					appendArrows: $nav ? $nav : false,
				});
			});
		}
	};
	/////////////////////////////////////////

	// Product Main img Slick
	window.initializeProductMainImgSlick = function () {
		if ($('#product-main-img').length) {
			$('#product-main-img').slick({
				infinite: true,
				speed: 300,
				dots: false,
				arrows: true,
				fade: true,
				asNavFor: '#product-imgs',
			});
		}
	};

	// Product imgs Slick
	window.initializeProductImgsSlick = function () {
		if ($('#product-imgs').length) {
			$('#product-imgs').slick({
				slidesToShow: 3,
				slidesToScroll: 1,
				arrows: true,
				centerMode: true,
				focusOnSelect: true,
				centerPadding: 0,
				vertical: true,
				asNavFor: '#product-main-img',
				responsive: [{
					breakpoint: 991,
					settings: {
						vertical: false,
						arrows: false,
						dots: true,
					}
				}]
			});
		}
	};

	$(document).ready(function () {
		window.initializeProductsSlick();
		window.initializeProductMainImgSlick();
		window.initializeProductImgsSlick();
		window.initializeProductWidgetSlick();
	});

	// Product img zoom
	var zoomMainProduct = document.getElementById('product-main-img');
	if (zoomMainProduct && $('#product-main-img .product-preview').length) {
		$('#product-main-img .product-preview').zoom();
	}

	/////////////////////////////////////////

	// Input number
	if ($('.input-number').length) {
		$('.input-number').each(function () {
			var $this = $(this),
				$input = $this.find('input[type="number"]'),
				up = $this.find('.qty-up'),
				down = $this.find('.qty-down');

			down.on('click', function () {
				var value = parseInt($input.val()) - 1;
				value = value < 1 ? 1 : value;
				$input.val(value);
				$input.change();
				updatePriceSlider($this, value)
			})

			up.on('click', function () {
				var value = parseInt($input.val()) + 1;
				$input.val(value);
				$input.change();
				updatePriceSlider($this, value)
			})
		});
	}

	var priceInputMax = document.getElementById('price-max'),
		priceInputMin = document.getElementById('price-min');


	if (priceInputMax) {
		priceInputMax.addEventListener('change', function () {
			updatePriceSlider($(this).parent(), this.value)
		});
	}

	if (priceInputMin) {
		priceInputMin.addEventListener('change', function () {
			updatePriceSlider($(this).parent(), this.value)
		});
	}

	function updatePriceSlider(elem, value) {
		if (elem.hasClass('price-min')) {
			console.log('min')
			priceSlider.noUiSlider.set([value, null]);
		} else if (elem.hasClass('price-max')) {
			console.log('max')
			priceSlider.noUiSlider.set([null, value]);
		}
	}

	// Price Slider
	window.initializePriceSlider = function (minRange, maxRange, startMin, startMax, dotNetHelper) {
		var priceSlider = document.getElementById('price-slider');
		var minInput = document.getElementById('price-min');
		var maxInput = document.getElementById('price-max');

		if (priceSlider) {
			noUiSlider.create(priceSlider, {
				start: [startMin, startMax],
				connect: true,
				step: 10,
				range: {
					'min': minRange,
					'max': maxRange
				}
			});
			console.log(priceSlider)
			console.log(startMax)
			console.log(startMin)

			// Update input fields
			priceSlider.noUiSlider.on('update', function (values, handle) {
				// Update the Blazor component properties
				dotNetHelper.invokeMethodAsync('UpdatePriceFilter', parseFloat(values[0]), parseFloat(values[1]));
			});

			// Trigger Blazor binding on change
			priceSlider.noUiSlider.on('change', function (values, handle) {
				minInput.dispatchEvent(new Event('input'));
				maxInput.dispatchEvent(new Event('input'));
			});

			// Update slider when input values change
			minInput.addEventListener('change', function () {
				priceSlider.noUiSlider.set([this.value, null]);
			});

			maxInput.addEventListener('change', function () {
				priceSlider.noUiSlider.set([null, this.value]);
			});
		}

		initializeInputNumber('price-min', priceSlider, minRange, maxRange);
		initializeInputNumber('price-max', priceSlider, minRange, maxRange);
	};

	function initializeInputNumber(inputId, slider, minRange, maxRange) {
		var input = document.getElementById(inputId);
		var inputNumber = input.parentElement;
		var up = inputNumber.querySelector('.qty-up');
		var down = inputNumber.querySelector('.qty-down');

		up.addEventListener('click', function () {
			var value = Math.min((parseFloat(input.value) + 10), maxRange);
			input.value = value;
			input.dispatchEvent(new Event('change'));
		});

		down.addEventListener('click', function () {
			var value = Math.max((parseFloat(input.value) - 10), minRange);
			input.value = value;
			input.dispatchEvent(new Event('change'));
		});
	}

})(jQuery);
