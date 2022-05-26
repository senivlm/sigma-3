using Task3;
using System;
using System.Text;

class Program{
    public static void Main(string[]args){
        matrixTask();
        vectorTask();
    }

    private static void matrixTask(){
        Console.WriteLine("MatrixTask");
        Matrix matrix = new Matrix(4);
        matrix.fillDiagonal(Matrix.StartDirection.RIGHT);
        matrix.printMatrix();
    }
    private static void vectorTask(){
        Console.WriteLine("VectorTask");
        Vector vector = new Vector(new int[] {1,2,3,13,1,3,13,1,1,33,33,33,3});
        System.Text.StringBuilder sb = new StringBuilder();
        foreach(int i in vector.getMaxSubSeq()){
            sb.Append($"|{i}|");
        }
        Console.WriteLine(sb);
        Console.WriteLine(vector);
    }
}