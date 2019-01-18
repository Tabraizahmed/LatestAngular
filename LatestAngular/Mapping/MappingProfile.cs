using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LatestAngular.Models;
using LatestAngular.Resources;

namespace LatestAngular.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to Api Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact,
                    opt => opt.MapFrom(v => new ContactResource
                        {ContactEmail = v.ContactEmail, ContactName = v.ContactName, ContactPhone = v.ContactPhone}))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(x => x.FeatureId)));


            //Api resource to domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v=>v.Id,opt=>opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.ContactName))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.ContactEmail))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.ContactPhone))
                .ForMember(v=>v.Features,opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature{FeatureId = id})))
                .AfterMap((vr, v) =>
                {
                    //Remove Selected features
                    var removedSelectedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach (var f in removedSelectedFeatures)
                            v.Features.Remove(f);

                    //Add new selected features
                    var addedFeatures = vr.Features.Where(id => v.Features.All(f => f.FeatureId != id))
                        .Select(id => new VehicleFeature {FeatureId = id});
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                }); 

         
         
        }
    }
}
