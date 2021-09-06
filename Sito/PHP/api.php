<?php header('Access-Control-Allow-Origin: *'); ?>
<?php

$linea=$_POST['linea'];
$codiceqr=$_POST['codiceqr'];
$inizio=$_POST['inizio'];
$fine=$_POST['fine'];
$conx=mysqli_connect("bb4guwdx6vaaqx95ix7h-mysql.services.clever-cloud.com","uzdvzunx5mjtnyad","2pR6rqfLqYbMfLa1XqwF","bb4guwdx6vaaqx95ix7h");
$comando="INSERT INTO `biglietti`(`linea`, `codiceqr`, `inizioAbbonamento`, `fineAbbonamento`) VALUES ('$linea','$codiceqr','$inizio','$fine');";
$result=mysqli_query($conx,$comando);
if($result==true)
	echo "true";

?>