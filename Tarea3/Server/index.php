<?php

require_once 'JuegoTikTakToe.php';
 

 $game=new JuegoTikTakToe();

 $tableroPrueba=array(
 	array('X','X','-'),
 	array('-','-','-'),
 	array('-','-','-'));

 $game->tableroToString($tableroPrueba);

 echo $game->placeToken("XX-------");

if (isset($_GET['wsdl'])) {
	header('Content-Type: application/soap+xml; charset=utf-8');
	echo file_get_contents('TikTakToe.wsdl');
}
else {
	 //Evitar problemas de cache
	ini_set('soap.wsdl_cache_enabled', '0');
	ini_set('soap.wsdl_cache_ttl', '0');
	
	session_start();
	$servidorSoap = new SoapServer('http://titanic.ecci.ucr.ac.cr/~eb92570/Tarea3/?wsdl');

	//Para evitar la excepción por defecto de SOAP PHP cuando no existe HTTP_RAW_POST_DATA,
	//se regresa explícitamente el siguiente fallo cuando no hay solicitud (v.b. desde un navegador)
	if(!@$HTTP_RAW_POST_DATA){
		$servidorSoap->fault('SOAP-ENV:Client', 'Invalid Request');
		exit;
	}

	$servidorSoap->setClass('JuegoTikTakToe');
	$servidorSoap->setPersistence(SOAP_PERSISTENCE_SESSION);
	$servidorSoap->handle();
}

?>

