using AbstractFactory.抽象产品;
using AbstractFactory.抽象工厂;

CheapFactory cheap = new CheapFactory();
IKFCDrink drink = cheap.GetKFCDrink();
drink.show();