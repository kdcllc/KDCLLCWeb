<<<<<<< HEAD
$.validator.addMethod("zipcodeUS", function(value, element) {
	return this.optional(element) || /^\d{5}(-\d{4})?$/.test(value);
}, "The specified US ZIP Code is invalid");
=======
$.validator.addMethod( "zipcodeUS", function( value, element ) {
	return this.optional( element ) || /^\d{5}(-\d{4})?$/.test( value );
}, "The specified US ZIP Code is invalid" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
