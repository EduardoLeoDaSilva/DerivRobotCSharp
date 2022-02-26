namespace DerivSmartRobot.Interfaces.Services;

public interface IRobotMapperFactory
{
    IRobotOperations CreateRiseAndUnderRobot();
    IRobotOperations CreateEvenAndOddRobot();
    IRobotOperations CreateDigitRobot();
}