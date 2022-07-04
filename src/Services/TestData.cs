using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(VectorDto movingObjectPosition)
    {
        var width = 10;
        var height = 8;

        var prototypeMap = new List<CellDto>();
        
        prototypeMap.Add(new CellDto("0", movingObjectPosition, "player", "", 100));
        
        
        for (var i = 0; i < 10; i++)
            prototypeMap.Add(new CellDto((i + 1).ToString(), new VectorDto {X = i, Y = 0}, "wall", "", 20));
        
        for (var i = 0; i < 10; i++)
            prototypeMap.Add(new CellDto((i + 10).ToString(), new VectorDto {X = i, Y = 7}, "wall", "", 20));
        
        for (var i = 0; i < 8; i++)
            prototypeMap.Add(new CellDto((i + 20).ToString(), new VectorDto {X = 0, Y = i}, "wall", "", 20));
        
        for (var i = 0; i < 8; i++)
            prototypeMap.Add(new CellDto((i + 30).ToString(), new VectorDto {X = 9, Y = i}, "wall", "", 20));

        return new GameDto(prototypeMap.ToArray(), true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
    }
}