/*
* Valida CEPs do brasileiros:
*
* Formatos aceitos:
* 99999-999
* 99.999-999
* 99999999
*/
<<<<<<< HEAD
$.validator.addMethod("postalcodeBR", function(cep_value, element) {
	return this.optional(element) || /^\d{2}.\d{3}-\d{3}?$|^\d{5}-?\d{3}?$/.test( cep_value );
}, "Informe um CEP válido.");
=======
$.validator.addMethod( "postalcodeBR", function( cep_value, element ) {
	return this.optional( element ) || /^\d{2}.\d{3}-\d{3}?$|^\d{5}-?\d{3}?$/.test( cep_value );
}, "Informe um CEP válido." );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
