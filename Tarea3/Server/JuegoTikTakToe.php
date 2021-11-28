<?php 
class JuegoTikTakToe{
    public $tablero;
  function __construct()
  {
    $this->tablero=array(
      array('X','X',''),
      array('','',''),
      array('','','') 
    );
  }

  function getEspaciosVacios($tablero){
    $vacios=[];
    for($i=0;$i<3;$i++){
      for($j=0;$j<3;$j++){
        if($tablero[$i][$j]=='-'){
            $coordenada= $i.$j."<br>";
            array_push($vacios,$coordenada);
        }
      }
    }
    return $vacios;
}


  function jugadaCompuInteligente($tablero){
    $coordenadas="";
    if($tablero[0][0]==$tablero[0][1] && $tablero[0][0]!="-" && $tablero[0][2]== "-"){
      $coordenadas = "02";
    }
    else if ($tablero[0][1]==$tablero[0][2]  && $tablero[0][1]!="-"  && $tablero[0][0]== "-"){
      $coordenadas = "00";
    }
    else if ($tablero[1][0]==$tablero[1][1]  && $tablero[1][0]!="-"  && $tablero[1][2]== "-"){
      $coordenadas = "12";
    }
    else if ($tablero[1][2]==$tablero[1][1]  && $tablero[1][2]!="-"  && $tablero[1][0]== "-"){
      $coordenadas = "10";
    }
    else if ($tablero[2][0]==$tablero[2][1]  && $tablero[2][0]!="-"  && $tablero[2][2]== "-"){
      $coordenadas = "22";
    }
    else if ($tablero[2][2]==$tablero[2][1]  && $tablero[2][2]!="-"  && $tablero[2][0]== "-"){
      $coordenadas = "20";
    }
    else if ($tablero[0][0]==$tablero[0][2]  && $tablero[0][0]!="-"  && $tablero[0][1]== "-"){
      $coordenadas = "01";
    }
    else if ($tablero[1][0]==$tablero[1][2]  && $tablero[1][0]!="-"  && $tablero[1][1]== "-"){
      $coordenadas = "11";
    }
    else if ($tablero[2][0]==$tablero[2][2]  && $tablero[2][0]!="-"  && $tablero[2][1]== "-"){
      $coordenadas = "21";
    }
    else if ($tablero[0][0]==$tablero[1][1]  && $tablero[0][0]!="-"  && $tablero[2][2]== "-"){
      $coordenadas = "22";
    }
    else if ($tablero[2][2]==$tablero[1][1]  && $tablero[2][2]!="-"  && $tablero[0][0]== "-"){
      $coordenadas = "00";
    }
    else if ($tablero[0][2]==$tablero[1][1]  && $tablero[0][2]!="-"  && $tablero[2][0]== "-"){
      $coordenadas = "20";
    }
    else if ($tablero[2][0]==$tablero[1][1]  && $tablero[2][0]!="-"  && $tablero[0][2]== "-"){
      $coordenadas = "02";
    }
    return $coordenadas;
  }
  function tableroToString($tablero){
    foreach($tablero as $fila){
      foreach($fila as $celda){
        echo $celda . "";
      }
      echo "<br><br>";
    }  
  }
  function jugadaCompu($tablero){
    $jugadaInteligente=$this->jugadaCompuInteligente($tablero);
    if($jugadaInteligente==""){
    $this->tableroToString($tablero);
      $posiblesCeldas=$this->getEspaciosVacios($tablero);
      $key=array_rand($posiblesCeldas);
      $xCoordinate= $posiblesCeldas[$key][0];
      $yCoordinate = $posiblesCeldas[$key][1];
    }

    else{
      $xCoordinate=$jugadaInteligente[0];
      $yCoordinate = $jugadaInteligente[1];
    }
    return $xCoordinate.$yCoordinate;
  }

  function stringToMatriz($tableroString){
    $tablero=array(
      array('','',''),
      array('','',''),
      array('','','') 
    );
    $counter=0;
    for($i=0;$i<3;$i++){
      for($j=0;$j<3;$j++){
          $tablero[$i][$j]=$tableroString[$counter++];
      }
    }
    return $tablero;
  }
  function placeToken($tablero)
  {
    $tablero=$this->stringToMatriz($tablero);    
    $ganador = $this->checkWinningConditions($tablero);
    if($ganador=="nadie") {
        $coordenadasJugadaCompu=$this->jugadaCompu($tablero);
    }
    else {
        $coordenadasJugadaCompu=$ganador;
    }
    return $coordenadasJugadaCompu;
  }

function getTablero(){
    return $this->tablero;
  }
  
function getFila($tablero,$fila) {
  return($tablero[$fila][0].$tablero[$fila][1].$tablero[$fila][2]);
}

function getColumna($tablero,$columna) {
  return($tablero[0][$columna].$tablero[1][$columna].$tablero[2][$columna]);
}

function getDiagonal1($tablero) {
  return($tablero[0][0].$tablero[1][1].$tablero[2][2]);
}

function getDiagonal2($tablero) {
  return($tablero[2][2].$tablero[1][1].$tablero[0][0]);
}

function checkWinningConditions($tablero) {
  $winner = "nadie";
  $contador = 0;
  while($contador<3 && $winner=="nadie") {
    if($this->getFila($tablero,$contador)=="XXX") {
      $winner = "X";
    }
    else if($this->getFila($tablero,$contador)=="OOO") {
      $winner = "O";
    }
    else if($this->getColumna($tablero,$contador)=="XXX") {
      $winner = "X";
    }
    else if($this->getColumna($tablero,$contador)=="OOO") {
      $winner = "O";
    }
    $contador += 1;
  }
  if($winner=="nadie") {
    if($this->getDiagonal1($tablero)=="XXX") {
      $winner="X";
    }
    if($this->getDiagonal1($tablero)=="OOO") {
      $winner="O";
    }
    if($this->getDiagonal2($tablero)=="XXX") {
      $winner="X";
    }
    if($this->getDiagonal2($tablero)=="OOO") {
      $winner="O";
    }
  }
  return($winner);
}
}
?>
