// TODO check if value starts with <, otherwise don't try stripping anything
<<<<<<< HEAD
$.validator.addMethod("strippedminlength", function(value, element, param) {
	return $(value).text().length >= param;
}, $.validator.format("Please enter at least {0} characters"));
=======
$.validator.addMethod( "strippedminlength", function( value, element, param ) {
	return $( value ).text().length >= param;
}, $.validator.format( "Please enter at least {0} characters" ) );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
