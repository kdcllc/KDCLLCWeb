/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: FI
 */
<<<<<<< HEAD
$.extend($.validator.methods, {
	date: function(value, element) {
		return this.optional(element) || /^\d{1,2}\.\d{1,2}\.\d{4}$/.test(value);
	},
	number: function(value, element) {
		return this.optional(element) || /^-?(?:\d+)(?:,\d+)?$/.test(value);
	}
});
=======
$.extend( $.validator.methods, {
	date: function( value, element ) {
		return this.optional( element ) || /^\d{1,2}\.\d{1,2}\.\d{4}$/.test( value );
	},
	number: function( value, element ) {
		return this.optional( element ) || /^-?(?:\d+)(?:,\d+)?$/.test( value );
	}
} );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
