/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: DE
 */
<<<<<<< HEAD
$.extend($.validator.methods, {
	date: function(value, element) {
		return this.optional(element) || /^\d\d?\.\d\d?\.\d\d\d?\d?$/.test(value);
	},
	number: function(value, element) {
		return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
	}
});
=======
$.extend( $.validator.methods, {
	date: function( value, element ) {
		return this.optional( element ) || /^\d\d?\.\d\d?\.\d\d\d?\d?$/.test( value );
	},
	number: function( value, element ) {
		return this.optional( element ) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test( value );
	}
} );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
