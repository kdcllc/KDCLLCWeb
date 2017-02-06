<<<<<<< HEAD
$.validator.addMethod("nowhitespace", function(value, element) {
	return this.optional(element) || /^\S+$/i.test(value);
}, "No white space please");
=======
$.validator.addMethod( "nowhitespace", function( value, element ) {
	return this.optional( element ) || /^\S+$/i.test( value );
}, "No white space please" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
