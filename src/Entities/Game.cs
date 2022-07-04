using System;
using System.Numerics;

namespace thegame.Models;

public class Game
{
    private EnumMapCell[,] gameMap; //[y, x]
    private Vector2 playerPosition;
    private Guid gameId = Guid.Empty;
    private bool isGameFinished;
    private int score;

    public void HandlePlayerStep(Vector2 move)
    {
        var destinationCoords = playerPosition + move;
        if (!DoesEntityStayInMap(destinationCoords))
            return;

        var destCell = gameMap[(int)destinationCoords.Y, (int)destinationCoords.X];

        if (destCell == EnumMapCell.Wall)
            return;
        if (destCell == EnumMapCell.Empty)
            MovePlayerTo(destinationCoords);
        if (destCell == EnumMapCell.Package)
        {
            var packageDestCoord = destinationCoords + move;
            if (!DoesEntityStayInMap(packageDestCoord))
                return;
            var packDestCell = gameMap[(int)destinationCoords.Y, (int)destinationCoords.X];
            if (packDestCell == EnumMapCell.Empty)
            {
                MovePlayerTo(destinationCoords);
                SetEntityTo( packageDestCoord, EnumMapCell.Package);
            }
        }
    }

    public GameDto GetGameDto()
    {
        var cells = new CellDto[gameMap.GetLength(0) * gameMap.GetLength(1)];
        var lineLen = gameMap.GetLength(1);
        var cellIndex = 1;
        for (var y = 0; y < gameMap.GetLength(0); y++)
        for (var x = 0; x < gameMap.GetLength(1); x++)
        {
            var cell = gameMap[y, x];
            cells[cellIndex - 1] = new CellDto(cellIndex.ToString(), new VectorDto {X = x, Y = y}, GetCssClass(cell),
                "", GetZIndex(cell));
        }
        return new GameDto(cells, true, true, lineLen, gameMap.GetLength(0), gameId, isGameFinished,score);
    }

    private string GetCssClass(EnumMapCell cellEntity)
    {
        if (cellEntity == EnumMapCell.Wall)
            return "wall";
        if (cellEntity == EnumMapCell.Player)
            return "player";
        if (cellEntity == EnumMapCell.Package)
            return "box";
        if (cellEntity == EnumMapCell.Target)
            return "target";
        return "";
    }
    
    private int GetZIndex(EnumMapCell cellEntity)
    {
        if (cellEntity == EnumMapCell.Player)
            return 2;
        if (cellEntity == EnumMapCell.Target)
            return 0;
        return 1;
    }

    private bool DoesEntityStayInMap(Vector2 destinationCoords)
    {
        if (destinationCoords.X < 0 || 
            destinationCoords.Y < 0 || 
            destinationCoords.X >= gameMap.GetLength(0) || 
            destinationCoords.Y >= gameMap.GetLength(1))
            return false;
        return true;
    }

    private void MovePlayerTo(Vector2 destinationCoords)
    {
        gameMap[(int) destinationCoords.Y, (int) destinationCoords.X] = EnumMapCell.Player;
        gameMap[(int) playerPosition.Y, (int) playerPosition.X] = EnumMapCell.Empty;
        playerPosition = destinationCoords;
    }

    private void SetEntityTo(Vector2 destinationCoords, EnumMapCell entity)
    {
        gameMap[(int) destinationCoords.Y, (int) destinationCoords.X] = entity;
    }
}