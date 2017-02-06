<<<<<<< HEAD
jQuery.validator.addMethod( "notEqualTo", function( value, element, param ) {
	return this.optional(element) || !$.validator.methods.equalTo.call( this, value, element, param );
=======
$.validator.addMethod( "notEqualTo", function( value, element, param ) {
	return this.optional( element ) || !$.validator.methods.equalTo.call( this, value, element, param );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
}, "Please enter a different value, values must not be the same." );
