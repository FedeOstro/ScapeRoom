namespace ScapeRoom.Models;

    public class Maze
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char[,] MazeData { get; private set; }
        public int StartRow { get; private set; }
        public int StartCol { get; private set; }
        public int EndRow { get; private set; }
        public int EndCol { get; private set; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            MazeData = new char[height, width];
        }

        public void GenerateMaze()
        {
            // Inicializar el laberinto con paredes en todas las celdas
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    MazeData[row, col] = '#';
                }
            }

            // Elegir una posición aleatoria como punto de partida
            Random random = new Random();
            int startRow = random.Next(Height);
            int startCol = random.Next(Width);

            // Establecer la posición de inicio y fin
            StartRow = startRow;
            StartCol = startCol;
            EndRow = random.Next(Height);
            EndCol = random.Next(Width);
            MazeData[startRow, startCol] = 'S';
            MazeData[EndRow, EndCol] = 'E';

            // Lista para almacenar las celdas visitadas
            List<Tuple<int, int>> visitedCells = new List<Tuple<int, int>>();
            visitedCells.Add(new Tuple<int, int>(startRow, startCol));

            // Lista para almacenar las paredes disponibles
            List<Tuple<int, int>> walls = new List<Tuple<int, int>>();

            // Agregar las paredes de las celdas vecinas a la lista de paredes
            AddNeighborWalls(startRow, startCol, walls);

            while (walls.Count > 0)
            {
                // Elegir una pared aleatoria de la lista de paredes
                int randomIndex = random.Next(walls.Count);
                Tuple<int, int> wall = walls[randomIndex];

                // Obtener las celdas vecinas de la pared
                int neighborRow = wall.Item1;
                int neighborCol = wall.Item2;

                // Verificar si una celda vecina ya ha sido visitada
                bool isVisited = IsCellVisited(neighborRow, neighborCol, visitedCells);

                // Contar el número de celdas vecinas visitadas
                int visitedCount = CountVisitedNeighbors(neighborRow, neighborCol, visitedCells);

                if (!isVisited && visitedCount == 1)
                {
                    // Eliminar la pared y marcar la celda vecina como visitada
                    RemoveWallBetweenCells(wall.Item1, wall.Item2, neighborRow, neighborCol);
                    visitedCells.Add(new Tuple<int, int>(neighborRow, neighborCol));

                    // Agregar las paredes de las celdas vecinas a la lista de paredes
                    AddNeighborWalls(neighborRow, neighborCol, walls);
                }

                // Eliminar la pared de la lista de paredes
                walls.RemoveAt(randomIndex);
            }
        
            // Establecer la posición de inicio y fin
            StartRow = 0;
            StartCol = 0;
            EndRow = Height - 1;
            EndCol = Width - 1;
            MazeData[StartRow, StartCol] = 'S';
            MazeData[EndRow, EndCol] = 'E';
        }
        private void AddNeighborWalls(int row, int col, List<Tuple<int, int>> walls)
        {
            // Agregar las paredes de las celdas vecinas a la lista de paredes
            if (row > 0)
            {
                walls.Add(new Tuple<int, int>(row - 1, col));
            }
            if (row < Height - 1)
            {
                walls.Add(new Tuple<int, int>(row + 1, col));
            }
            if (col > 0)
            {
                walls.Add(new Tuple<int, int>(row, col - 1));
            }
            if (col < Width - 1)
            {
                walls.Add(new Tuple<int, int>(row, col + 1));
            }
        }
        private bool IsCellVisited(int row, int col, List<Tuple<int, int>> visitedCells)
        {
            // Verificar si una celda ya ha sido visitada
            return visitedCells.Contains(new Tuple<int, int>(row, col));
        }
        private int CountVisitedNeighbors(int row, int col, List<Tuple<int, int>> visitedCells)
        {
            // Contar el número de celdas vecinas visitadas
            int count = 0;
            if (row > 0 && IsCellVisited(row - 1, col, visitedCells))
            {
                count++;
            }
            if (row < Height - 1 && IsCellVisited(row + 1, col, visitedCells))
            {
                count++;
            }
            if (col > 0 && IsCellVisited(row, col - 1, visitedCells))
            {
                count++;
            }
            if (col < Width - 1 && IsCellVisited(row, col + 1, visitedCells))
            {
                count++;
            }
            return count;
        }
        private void RemoveWallBetweenCells(int row1, int col1, int row2, int col2)
        {
            // Eliminar la pared entre dos celdas adyacentes
            int wallRow = (row1 + row2) / 2;
            int wallCol = (col1 + col2) / 2;
            MazeData[wallRow, wallCol] = ' ';
        }

        public bool CheckCollision(int row, int col)
        {
            // Verificar si hay una colisión en la posición dada
            if (row < 0 || row >= Height || col < 0 || col >= Width || MazeData[row, col] == '#')
            {
                return true; // Hay una colisión con una pared
            }

            return false; // No hay colisión
        }

        public bool CheckEnd(int row, int col)
        {
            // Verificar si se ha llegado al final del laberinto
            if (row == EndRow && col == EndCol)
            {
                return true; // Se ha llegado al final
            }

            return false; // No se ha llegado al final
        }
    }

