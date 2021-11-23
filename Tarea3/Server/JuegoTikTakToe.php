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
  

}
?>
