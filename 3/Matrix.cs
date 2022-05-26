namespace Task3;
    
    class Matrix{
        private enum Directions{RIGHT, LEFT_DOWN, DOWN, RIGHT_UP}
        public enum StartDirection{DOWN = Directions.DOWN, RIGHT = Directions.RIGHT}
        private int [,] matrix;
        
        public Matrix(int len){
            matrix = new int[len, len];
        }

        public void printMatrix(){
            for(int col = 0; col < matrix.GetLength(0); col ++){
                for(int row = 0; row < matrix.GetLength(1); row++){
                    Console.Write($"|{matrix[row,col]}|");
                }
                Console.WriteLine();
            }
        }

        public void filSpiral(){
            int size = matrix.GetLength(0) * matrix.GetLength(1);

            int fill = 1;
            while(fill < size){
                
            }
        }
        public void fillVertSnake(){
            bool reverse = false;
            int fill = 1;
            for(int col = 0; col < matrix.GetLength(0); col ++){
                if(!reverse){
                    for(int row = 0; row < matrix.GetLength(1); row++){
                        matrix[col, row] = fill++;
                    }
                }else{
                    for(int row = matrix.GetLength(1) - 1; row >= 0; row--){
                        matrix[col, row] = fill++;
                    }
                }
                reverse = !reverse;
            }
        }

        public void fillDioganalSnake(){
            if(matrix.GetLength(1) != matrix.GetLength(0)){
                Console.WriteLine("isn't square");
                return;
            }

            int width = matrix.GetLength(0);
            int number=0;
            for(int line =0; line < width; line++)
            {
                if(line % 2 == 0)
                {
                    int i1 = line;
                    int j1 = 0;
                    for (int i = 0; i < line + 1; i++)
                    {
                        matrix[i1, j1] =++number;
                        i1--;
                        j1++;
                    }
                }
                else
                {
                    int i1 = 0;
                    int j1 = line;
                    for (int i = 0; i < line + 1; i++)
                    {
                        matrix[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }
            }

             Console.WriteLine("lower");
            for(int col = 1; col < width; col ++)
            {
                Console.WriteLine($"col {col}");
                if(col % 2 == 0){
                    int i1 = col;
                    int j1 = width - 1; 
                    for(int i = col; i <width; i ++){
                        matrix[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }else{
                    int i1 = width - 1;
                    int j1 = col; 
                    for(int i = col; i <width; i ++){
                        matrix[i1, j1] = ++number;
                        i1--;
                        j1++;
                    }
                }
            }
        }

        public void fillDiagonal(StartDirection _direction){

            int col = 0;
            int row = 0;
            int fill;
            Directions direction = (Directions)_direction;

            for(fill = 1;fill <= matrix.Length; fill++){
                matrix[col,row] = fill;
                switch(direction){
                    case Directions.RIGHT:{
                        col++;
                        if(row == 0){
                            direction = Directions.LEFT_DOWN;
                        }else{
                            direction = Directions.RIGHT_UP;
                        }
                        break;
                    }
                    case Directions.DOWN:{
                        row++;
                        if(col == 0){
                            direction = Directions.RIGHT_UP;
                        }else{
                            direction = Directions.LEFT_DOWN;
                        }
                        break;
                    }
                    case Directions.LEFT_DOWN:{
                        row++;
                        col--;
                        if(col == 0){
                            direction = Directions.DOWN;
                        }
                        if(row == matrix.GetLength(0)-1){
                            direction = Directions.RIGHT;
                        }
                        
                        break;
                    }
                    case Directions.RIGHT_UP:{
                        row--;
                        col++;
                        if(col == (matrix.GetLength(0) - 1)){
                            direction = Directions.DOWN;
                        }else
                        if(row == 0){
                            direction = Directions.RIGHT;
                        }
                        break;
                    }
                }
            }
        }
    }