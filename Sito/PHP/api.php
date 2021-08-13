<?php header('Access-Control-Allow-Origin: *'); ?>
<?php
define("DATABASE", "database.json");

//controlla se viene dato con comando giusto (get_update | set_string | set_boolean)
if (!isset($_GET) || !isset($_GET["action"]))
	die("no action provided");

$action = $_GET["action"];
//se il comando è get_update restituisco il database
if ($action == "get_update")
	die(file_get_contents(DATABASE));
//se i dati forniti sono nulli restituisco un errore
if (!isset($_GET["data"]))
	die("no data provided"); 

$data = base64_decode($_GET["data"]);

switch ($action)
{
	case "set_bottoni":
		set_bottoni($data);
		break;
	case "set_scene":
		set_scene($data);
		break;
	
	default:
		die("invalid action provided");
}

function set_bottoni($data)
{
	$decoded_data = explode("|", $data);
	
	$index = $decoded_data[0];
	$value = $decoded_data[1];
	//prendo il contenuto del database e lo aggiorno
	$database = json_decode(file_get_contents(DATABASE), true);
	$database["bottoni"][(int)$index] = filter_var($value, FILTER_VALIDATE_BOOLEAN);
	
	if (file_put_contents(DATABASE, json_encode($database, JSON_PRETTY_PRINT)))
		echo $index . " set to " . $value;
}
function set_scene($data)
{
	$decoded_data = explode("|", $data);
	
	$index = $decoded_data[0];
	$value = $decoded_data[1];
	//prendo il contenuto del database e lo aggiorno
	$database = json_decode(file_get_contents(DATABASE), true);
	$database["scene"][(int)$index] = filter_var($value, FILTER_VALIDATE_BOOLEAN);
	
	if (file_put_contents(DATABASE, json_encode($database, JSON_PRETTY_PRINT)))
		echo $index . " set to " . $value;
}


?>