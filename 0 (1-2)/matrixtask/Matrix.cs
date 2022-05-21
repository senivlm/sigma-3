namespace Task0;
    
    class Matrix{
        private enum Directions{RIGHT, LEFT_DOWN, DOWN, RIGHT_UP}
        private int [,] matrix;
        
        public Matrix(int cols, int rows){
            matrix = new int[cols, rows];
        }

        public void printMatrix(){
            for(int col = 0; col < matrix.GetLength(0); col ++){
                for(int row = 0; row < matrix.GetLength(1); row++){
                    Console.Write($"|{matrix[row,col]}|");
                }
                Console.WriteLine();
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
            int col = 0;
            int row = 0;
            int fill;
            Directions direction = Directions.RIGHT;

            for(fill = 1;fill <= matrix.Length; fill++){
                matrix[col,row] = fill;
                switch(direction){
                    case Directions.RIGHT:{
                        Console.WriteLine("right");
                        col++;
                        if(row == 0){
                            direction = Directions.LEFT_DOWN;
                        }else{
                            direction = Directions.RIGHT_UP;
                        }
                        break;
                    }
                    case Directions.DOWN:{
                        Console.WriteLine("down");
                        row++;
                        if(col == 0){
                            direction = Directions.RIGHT_UP;
                        }else{
                            direction = Directions.LEFT_DOWN;
                        }
                        break;
                    }
                    case Directions.LEFT_DOWN:{
                        Console.WriteLine("l_down");
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
                        Console.WriteLine("r_up");
                        row--;
                        col++;
                        if(col == matrix.GetLength(0) - 1){
                            direction = Directions.DOWN;
                        }
                        if(row == 0){
                            direction = Directions.RIGHT;
                        }
                        break;
                    }
                }
            }
        }
    }