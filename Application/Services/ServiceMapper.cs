using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class ServiceMapper : IMapper
    {
        private readonly IMapper _mapper;
        private readonly TypeAdapterConfig _config; 

        public ServiceMapper(TypeAdapterConfig config)
        {
            _config = config;
            _mapper = new Mapper(config);
        }

        public TypeAdapterConfig Config => _config;

        public ITypeAdapterBuilder<TSource> From<TSource>(TSource source)
        {
            return _mapper.From(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

        public object Map(object source, Type destinationType)
        {
            return _mapper.Map(source, destinationType);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, destination, sourceType, destinationType);
        }
    }
}
