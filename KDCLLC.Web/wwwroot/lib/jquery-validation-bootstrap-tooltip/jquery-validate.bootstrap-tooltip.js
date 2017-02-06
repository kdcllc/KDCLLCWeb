/**
 * @preserve
<<<<<<< HEAD
 * jQuery Validation Bootstrap Tooltip extention v0.10.1
 *
 * https://github.com/Thrilleratplay/jQuery-Validation-Bootstrap-tooltip
 *
 * Copyright 2015 Tom Hiller
 * Released under the MIT license:
 * http://www.opensource.org/licenses/mit-license.php
 */
(function($) {
  $.extend(true, $.validator, {
    prototype: {
      defaultShowErrors: function() {
        var _this = this;
        var bsVersion = $.fn.tooltip.Constructor.VERSION;
        var bsMajorVer =  0;
        var bsMinorVer = 0;
=======
 * jQuery Validation Bootstrap Tooltip extention v0.10.2
 *
 * https://github.com/Thrilleratplay/jQuery-Validation-Bootstrap-tooltip
 *
 * Copyright 2016 Tom Hiller
 * Released under the MIT license:
 * http://www.opensource.org/licenses/mit-license.php
 */
(function ($) {
  var bsMajorVer = 0;
  var bsMinorVer = 0;

  $.extend(true, $.validator, {
    prototype: {
      defaultShowErrors: function () {
        var _this = this;
        var bsVersion = $.fn.tooltip.Constructor.VERSION;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

        // Try to determine Bootstrap major and minor versions
        if (bsVersion) {
          bsVersion = bsVersion.split('.');
          bsMajorVer = parseInt(bsVersion[0]);
          bsMinorVer = parseInt(bsVersion[1]);
        }

<<<<<<< HEAD
        $.each(this.errorList, function(index, value) {
          //If Bootstrap 3.3 or greater
          if (bsMajorVer === 3 && bsMinorVer >= 3) {
            var currentElement = $(value.element);
            if (currentElement.data('bs.tooltip') !== undefined) {
              currentElement.data('bs.tooltip').options.title = value.message;
            } else {
              currentElement.tooltip(_this.applyTooltipOptions(value.element, value.message));
            }

            $(value.element).removeClass(_this.settings.validClass).addClass(_this.settings.errorClass).tooltip('show');
          } else {
            $(value.element).removeClass(_this.settings.validClass).addClass(_this.settings.errorClass).tooltip(bsMajorVer === 4 ? 'dispose' : 'destroy').tooltip(_this.applyTooltipOptions(value.element, value.message)).tooltip('show');
=======
        $.each(this.errorList, function (index, value) {
          //If Bootstrap 3.3 or greater
          if (bsMajorVer === 3 && bsMinorVer >= 3) {
            var $currentElement = $(value.element);
            if ($currentElement.data('bs.tooltip') !== undefined) {
              $currentElement.data('bs.tooltip').options.title = value.message;
            } else {
              $currentElement.tooltip(_this.applyTooltipOptions(value.element, value.message));
            }

            $(value.element).removeClass(_this.settings.validClass)
                            .addClass(_this.settings.errorClass)
                            .tooltip('show');
          } else {
            $(value.element).removeClass(_this.settings.validClass)
                            .addClass(_this.settings.errorClass)
                            .tooltip(bsMajorVer === 4 ? 'dispose' : 'destroy')
                            .tooltip(_this.applyTooltipOptions(value.element, value.message))
                            .tooltip('show');
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
          }

          if (_this.settings.highlight) {
            _this.settings.highlight.call(_this, value.element, _this.settings.errorClass, _this.settings.validClass);
          }
        });

<<<<<<< HEAD
        $.each(_this.validElements(), function(index, value) {
          $(value).removeClass(_this.settings.errorClass).addClass(_this.settings.validClass).tooltip(bsMajorVer === 4 ? 'dispose' : 'destroy');
=======
        $.each(_this.validElements(), function (index, value) {
          $(value).removeClass(_this.settings.errorClass)
                  .addClass(_this.settings.validClass)
                  .tooltip(bsMajorVer === 4 ? 'dispose' : 'destroy');

>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
          if (_this.settings.unhighlight) {
            _this.settings.unhighlight.call(_this, value, _this.settings.errorClass, _this.settings.validClass);
          }
        });
      },

<<<<<<< HEAD
      applyTooltipOptions: function(element, message) {
        var options = {
          /* Using Twitter Bootstrap Defaults if no settings are given */
          animation: $(element).data('animation') || true,
          html: $(element).data('html') || false,
          placement: $(element).data('placement') || 'top',
          selector: $(element).data('selector') || false,
          title: $(element).attr('title') || message,
          trigger: $.trim('manual ' + ($(element).data('trigger') || '')),
          delay: $(element).data('delay') || 0,
          container: $(element).data('container') || false,
=======
      applyTooltipOptions: function (element, message) {
        var defaults;

        if (bsMajorVer === 4) {
          defaults = $.fn.tooltip.Constructor.Default;
        } else if (bsMajorVer === 3) {
          defaults = $.fn.tooltip.Constructor.DEFAULTS;
        } else {
          // Assuming BS version 2
          defaults = $.fn.tooltip.defaults;
        }

        var options = {
          /* Using Twitter Bootstrap Defaults if no settings are given */
          animation: $(element).data('animation') || defaults.animation,
          html: $(element).data('html') || defaults.html,
          placement: $(element).data('placement') || defaults.placement,
          selector: $(element).data('selector') || defaults.selector,
          title: $(element).attr('title') || message,
          trigger: $.trim('manual ' + ($(element).data('trigger') || '')),
          delay: $(element).data('delay') || defaults.delay,
          container: $(element).data('container') || defaults.container,
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
        };

        if (this.settings.tooltip_options && this.settings.tooltip_options[element.name]) {
          $.extend(options, this.settings.tooltip_options[element.name]);
        }
        /* jshint ignore:start */
        if (this.settings.tooltip_options && this.settings.tooltip_options['_all_']) {
          $.extend(options, this.settings.tooltip_options['_all_']);
        }
        /* jshint ignore:end */
        return options;
      },
    },
  });
}(jQuery));
