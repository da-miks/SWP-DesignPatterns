using _06_Factory_Pattern;

IVehicle v1 = VehicleFactory.CreateVehicle(VehicleTypes.Bus);
IVehicle v2 = VehicleFactory.CreateVehicle(VehicleTypes.Car);

v1.Move("Somewhere");
v2.Move("In the world");
Console.ReadKey();