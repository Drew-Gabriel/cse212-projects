public class Maze
{
    private Dictionary<(int, int), bool[]> _map;
    private int _x;
    private int _y;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        _map = map;
        _x = 1;
        _y = 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_x}, y={_y})";
    }

    public void MoveLeft()
    {
        Move(0);
    }

    public void MoveRight()
    {
        Move(1);
    }

    public void MoveUp()
    {
        Move(2);
    }

    public void MoveDown()
    {
        Move(3);
    }

    private void Move(int direction)
    {
        if (!_map.ContainsKey((_x, _y)))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        bool[] moves = _map[(_x, _y)];

        if (!moves[direction])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        switch (direction)
        {
            case 0: // Left
                _x--;
                break;

            case 1: // Right
                _x++;
                break;

            case 2: // Up
                _y--;
                break;

            case 3: // Down
                _y++;
                break;
        }

        if (!_map.ContainsKey((_x, _y)))
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
}