<<<<<<< HEAD
$.validator.addMethod("lettersonly", function(value, element) {
	return this.optional(element) || /^[a-z]+$/i.test(value);
}, "Letters only please");
=======
$.validator.addMethod( "lettersonly", function( value, element ) {
	return this.optional( element ) || /^[a-z]+$/i.test( value );
}, "Letters only please" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
