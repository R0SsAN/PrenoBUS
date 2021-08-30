<?php header('Access-Control-Allow-Origin: *'); ?>
<?php

$linea=$_POST['linea'];
$codiceqr=$_POST['codiceqr'];
$inizio=$_POST['inizio'];
$fine=$_POST['fine'];

$conx=mysqli_connect("remotemysql.com","UZ4rJQ4qBZ","xzZFVqol3S","UZ4rJQ4qBZ");
$comando="INSERT INTO `biglietti`(`linea`, `codiceqr`, `inizioAbbonamento`, `fineAbbonamento`) VALUES ('$linea','$codiceqr','$inizio','$fine');";
$result=mysqli_query($conx,$comando);
if($result==true)
	echo "true";

?>