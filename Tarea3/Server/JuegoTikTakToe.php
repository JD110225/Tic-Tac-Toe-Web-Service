<?php 
class JuegoTikTakToe{
    public $tablero;
  function __construct()
  {
    $this->tablero=array(
      array('X','X','X'),
      array('O','O','O'),
      array('X','X','X') 
    );
    $this->placeToken('H',1,1);
  }

function sendTableroClient(){
    $resultado='';
    foreach($this->tablero as $fila){
      foreach($fila as $celda){
        $resultado .= $celda;
      }
    }
    return $resultado;
  }

function placeToken($token,$row,$col)
{
  $this->tablero[$row][$col]=$token;
  return $this->sendTableroClient();
}

function getTablero(){
    return $this->tablero;
  }
  
function getFila($fila) {
  return($this->tablero[$fila][0]+$this->tablero[$fila][1]+$this->tablero[$fila][2]);
}

function getColumna($columna) {
  return($this->tablero[0][$columna]+$this->tablero[1][$columna]+$this->tablero[2][$columna]);
}

function getDiagonal1() {
  return($this->tablero[0][0]+$this->tablero[1][1]+$this->tablero[2][2]+);
}

function getDiagonal2() {
  return($this->tablero[2][2]+$this->tablero[1][1]+$this->tablero[0][0]+);
}

function checkWinningConditions() {
  $winner = "";
  $contador = 0;
  while($contador<3 && $winner=="") {
    if(getFila($contador)=="XXX") {
      $winner = "X";
    }
    else if(getFila($contador)=="OOO") {
      $winner = "O";
    }
    else if(getColumna($contador)=="XXX") {
      $winner = "X";
    }
    else if(getColumna($contador)=="OOO") {
      $winner = "O";
    }
  }
  if($winner=="") {
    if(getDiagonal1()=="XXX") {
      $winner="X";
    }
    if(getDiagonal1()=="OOO") {
      $winner="O";
    }
    if(getDiagonal2()=="XXX") {
      $winner="X";
    }
    if(getDiagonal2()=="OOO") {
      $winner="O";
    }
  }
  return($winner);
}
}
?>
