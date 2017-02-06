/**
 * Dutch giro account numbers (not bank numbers) have max 7 digits
 */
<<<<<<< HEAD
$.validator.addMethod("giroaccountNL", function(value, element) {
	return this.optional(element) || /^[0-9]{1,7}$/.test(value);
}, "Please specify a valid giro account number");
=======
$.validator.addMethod( "giroaccountNL", function( value, element ) {
	return this.optional( element ) || /^[0-9]{1,7}$/.test( value );
}, "Please specify a valid giro account number" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
