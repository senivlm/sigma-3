namespace Task1;

class Matrix{
    private int [,] matrix;

    public enum Directions{RIGHT, LEFT_DOWN, DOWN, RIGHT_UP}

    public Matrix(int rows){
        matrix = new int[rows, rows];
    }
    
    public void printMatrix(){
        for(int col = 0; col < matrix.GetLength(0); col ++){
            for(int row = 0; row < matrix.GetLength(1); row++){
                Console.Write($"|{matrix[row,col]}|");
            }
            Console.WriteLine();
        }
    }

    public void fillDiagonal(Directions _direction){
            if(_direction != Directions.DOWN || _direction != Directions.RIGHT){
                Console.WriteLine("unsupported direction");
            }
            int col = 0;
            int row = 0;
            int fill;
            Directions direction = _direction;

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