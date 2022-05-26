namespace Task1;

class Program{
    public static void Main(string[]args){
       vectorTask();

    }

    private static void matrixTask(){
        Matrix matrix = new Matrix(4);
        matrix.fillDiagonal(Matrix.Directions.RIGHT);
        matrix.printMatrix();
    }
    private static void vectorTask(){
        Vector vector = new Vector(new int[] {1,2,3,13,1,3,13,1,1,33,33,33,3});
        foreach(int i in vector.getMaxSubSeq()){
            Console.Write($"|{i}|");
        }
    }
}