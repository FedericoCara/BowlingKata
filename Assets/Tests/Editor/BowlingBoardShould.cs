using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BowlingBoardShould
{
    // Dado una secuencia válida de tiradas de bolos, devolver la puntuación total de la partida.
    //No comprobar la validez de las tiradas.
    //No comprobar el número de tiradas.
    //No proporcionar puntuaciones intermedias.

    //Cada partida se compone de 10 turnos.
    // Hay 10 bolos que se intentan tirar en cada turno.
    // En cada turno el jugador hace 2 tiradas.
    // Si en un turno el jugador no tira los 10 bolos, la puntuación del turno es el total
    //de bolos tirados.
    // Si en un turno el jugador tira los 10 bolos (un "spare"), la puntuación es 10 más
    //el número de bolos tirados en la siguiente tirada(del siguiente turno).
    // Si en la primera tirada del turno tira los 10 bolos(un "strike") el turno acaba y la
    //puntuación es 10 más el número de bolos de las dos tiradas siguientes.
    // Si el jugador logra un spare o un strike en el último turno, obtiene una o dos
    //tiradas más (respectivamente) de bonificación.Esas tiradas cuentan como
    //parte del mismo turno (el décimo).
    // Si en las tiradas de bonificación el jugador derriba todos los bolos, el proceso
    //no se repite, es decir que no se vuelven a generar más lanzamientos de
    //bonificación.
    //Nota: el puntaje generado en las tiradas de bonificación se suma a la
    //puntuación del turno final.


   [Test]
    public void SumAllStrikes()
    {
        //Given
        string points = "X X X X X X X X X X X X";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(300, totalPoints);
    }

    [Test]
    public void SumPairsWithOneMiss()
    {
        //Given
        string points = "3- 3- 3- 3- 3- 3- 3- 3- 3- 3-";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(30, totalPoints);
    }

    [Test]
    public void SumPairsWithOneMissFirst()
    {
        //Given
        string points = "-3 -3 -3 -3 -3 -3 -3 -3 -3 -3";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(30, totalPoints);
    }

    [Test]
    public void SumPairsWithSpare()
    {
        //Given
        string points = "7/ 7/ 7/ 7/ 7/ 7/ 7/ 7/ 7/ 7/7";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(170, totalPoints);
    }

    [Test]
    public void SumPairsWithSpareWithDifferentNumbers()
    {
        //Given
        string points = "7/ 3/ 6/ 2/ 1/ -/ 9/ 8/ 6/ 3/5";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(143, totalPoints);
    }

    [Test]
    public void SumPairsWithMissAndDifferentNumbers()
    {
        //Given
        string points = "5- -3 5- 6- -8 9- 3- 5- -3 --";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(47, totalPoints);
    }

    [Test]
    public void SumPairsWithMissDifferentNumbersAndStrikeInTheEnd()
    {
        //Given
        string points = "5- -3 X 6- X X 3- 5- -3 X 4 2";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(93, totalPoints);
    }

    [Test]
    public void SumPairsWithMissDifferentNumbersAndStrikes()
    {
        //Given
        string points = "5- -3 X 6- X X 3- 5- -3 6-";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(83, totalPoints);
    }

    [Test]
    public void SumPairsWithMissDifferentNumbersStrikesAndSpares()
    {
        //Given
        string points = "5/ -3 X 6/ X X 3- 5/ -3 6-";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(111, totalPoints);
    }

    [Test]
    public void SumPairsWithMissDifferentNumbersStrikesSparesAndTwoNumbersPair()
    {
        //Given
        string points = "5/ 53 X 6/ X X 3- 5/ 23 6-";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(125, totalPoints);
    }

    [Test]
    public void SumPairsWithMissDifferentNumbersAndStrikeAndSpareInTheEnd() {
        //Given
        string points = "7/ X 6- -- 9/ 11 11 11 11 X 8 /";
        //When
        int totalPoints = BowlingBoard.CalculateScore(points);
        //Then
        Assert.AreEqual(81, totalPoints);
    }

}
