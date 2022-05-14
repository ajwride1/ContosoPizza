using ContosoPizza.Models;

namespace ContosoPizza.Servoces;

public static class PizzaService
{
    static List<Pizza> Pizzas {get;}
    static int nextId = 3;
    
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza{ Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza{ Id = 2, Name = "Veggie", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetPizzas() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        Pizza? pizza = Get(id);
        
        if(pizza != null)
            Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        int index = Pizzas.FindIndex(p => p.Id == pizza.Id);

        if(index > 0)
            Pizzas[index] = pizza;   
    }
}