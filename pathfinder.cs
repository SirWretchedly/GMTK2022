using System;
using System.Collections;
using System.Collections.Generic;

class World {
    public int minX, maxX, minY, maxY;
    private HashSet<Position> obstacles;
    
    public World(int minX, int maxX, int minY, int maxY, HashSet<Position> obstacles) {
        this.maxX = maxX;
        this.maxY = maxY;
        this.minX = minX;
        this.minY = minY;
        this.obstacles = obstacles;
    }
    
    public bool isObstacle(Position pos) {
        return obstacles.Contains(pos);
    }
}

class Position {
    public int x, y;

    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }
    
    public Position move(Movement move) {
        return new Position(x + move.dx, y + move.dy);
    }
    
    public override int GetHashCode() {
        return 17 * x + y;
    }

    public override bool Equals(object obj) {
        if (obj == null) {
            return false;
        }
        
        if (ReferenceEquals(this, obj)) {
            return true;
        }

        if (this.GetType() != obj.GetType())
        {
            return false;
        }
        return Equals((Position) obj);
    }
    
    public bool Equals(Position obj) {
        return x == obj.x && y == obj.y;
    }
}

class Movement {
    public int dx, dy;

    public Movement(int dx, int dy) {
        this.dx = dx;
        this.dy = dy;
    }
}

static class Pathfinding {

    private static List<Movement> getMoves(World world, Position mover) {
        List<Movement> moves = new List<Movement>();
        int[] dx = {-1, 0, 1, 0};
        int[] dy = {0, -1, 0, 1};

        for (int i = 0; i < dx.Length; ++i) {
            moves.Add(new Movement(dx[i], dy[i]));
        }
        return moves;
    }

    private static List<Movement> getLegalMoves(World world, Position mover) {
        List<Movement> moves = getMoves(world, mover);
        List<Movement> legalMoves = new List<Movement>();
        
        foreach (Movement m in moves) {
            Position neighbour = mover.move(m);
            // check boundary
            if (neighbour.x < world.minX || neighbour.x > world.maxX
            || neighbour.y < world.minY || neighbour.y > world.maxY) {
                continue;
            }
            // check obstacle
            if (world.isObstacle(neighbour)) {
                continue;
            }
            legalMoves.Add(m);
        }
        return legalMoves;
    }

    public static Movement getMovement(World world, Position mover, Position target) {
        List<Movement> moves = getLegalMoves(world, mover);

        // get move that improves longest axis
        foreach (Movement move in moves) {
            if (Math.Abs(mover.x - target.x) > Math.Abs(mover.y - target.y)) {
                if (Math.Abs(mover.x + move.dx - target.x) < Math.Abs(mover.x - target.x)) {
                    return move;
                }
            } else {
                if (Math.Abs(mover.y + move.dy - target.y) < Math.Abs(mover.y - target.y)) {
                    return move;
                }
            }
        }

        // get best move left
        Movement bestMove = moves[0];
        foreach (Movement move in moves) {
            if (Math.Abs(mover.x + move.dx - target.x) + Math.Abs(mover.y + move.dy - target.y)
            < Math.Abs(mover.x - target.x) + Math.Abs(mover.y - target.y)) {
                bestMove = move;
            }
        }
        return bestMove;
    }
}

public class Tester
{
    public static void Main(string[] args)
    {
        HashSet<Position> obstacles = new HashSet<Position>();
        obstacles.Add(new Position(2, 1));
        obstacles.Add(new Position(2, 2));
        obstacles.Add(new Position(1, 3));
        World world = new World(0, 10, 0, 10, obstacles);
        Position mover = new Position(1, 2);
        Position target = new Position(2, 3);
        Movement move = Pathfinding.getMovement(world, mover, target);
        Console.WriteLine(move.dx);
        Console.WriteLine(move.dy);
    }
}
