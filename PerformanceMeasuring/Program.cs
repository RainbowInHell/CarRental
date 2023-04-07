using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CarRental.DLL.Entities;
using CarRental.BLL.DTO.ManufacturerViews;

public class Benchmark
{
    private Manufacturer[] _manufacturers;
    private IMapper _mapper;

    [Params(10, 100, 1000)]

    public int NumberOfElements { get; set; }

    [GlobalSetup]
    public void Init()
    {
        var config = new MapperConfiguration(cfg
            => cfg.CreateMap<Manufacturer, ManufacturerDTO>()
        );

        _mapper = config.CreateMapper();

        _manufacturers = Enumerable.Range(1, NumberOfElements)
            .Select(x => new Manufacturer
            {
                Id = x,
                Name = $"Manufacturer name {x}",
                VehicleModels = null
            })
            .ToArray();
    }

    [Benchmark]
    public void GetManufacturersAutoMap()
    {
        _mapper.Map<IEnumerable<ManufacturerDTO>>(_manufacturers);
    }

    [Benchmark]
    public void GetManufacturersWithoutAutoMap()
    {
        //_manufacturers.Select(manufacturer => (ManufacturerDTO)manufacturer);
    }
}

public class Program
{
    static int Main(string[] args)
    {
        try
        {
            BenchmarkRunner.Run<Benchmark>();
            return 0;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            return 1;
        }
    }
}