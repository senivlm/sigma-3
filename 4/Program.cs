using Task4;

public static class Program{
    public static void Main(string [] args){
        vectorTask();
    }

    private static void vectorTask(){
       Vector vector = new Vector(new int[]{3,2,55,4,2});
       try{
           vector.quickSort(2,11);
       }catch(ArgumentException e){
           Console.WriteLine(e.Message);
       }
       vector.quickSort(0, 4);
       
       Console.WriteLine(vector);
    }
}