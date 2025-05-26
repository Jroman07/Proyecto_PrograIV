using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services
{
    public class OfferService : IOfferService
    {

        private readonly FinalProjectDbContext _dbContext; // atributo de la base de datos para pderla usar 

        public OfferService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        } // se crea un constructor 

        public Offer AddOffer(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();

            return offer;
        } // añadir oferta

        public void DeleteOffer(int Id)
        {
            Offer? DeleteOffer = _dbContext.Offers.Find(Id);

            if (DeleteOffer != null){
                _dbContext.Offers.Remove(DeleteOffer);

                _dbContext.SaveChanges();
            }else{
                throw new Exception("Candidate not found");
            }
        } // borrar todos

        public List<Offer> GetallOffers()
        {
            return _dbContext.Offers.Include(x => x.Company).ToList();
        } // mostrar todos

        public Offer GetOfferById(int Id)
        {
            Offer? offer = _dbContext.Offers.Find(Id);

            if (offer != null){
                return offer;
            }else{
                throw new Exception("Offer not found");
            }
        }

        public List<Offer> GetOffersByCandidate(int Id)
        {
            Candidate candidate = _dbContext.Candidates.Find(Id);
            var candidateSkillIds = _dbContext.CandidateSkills
                .Where(cs => cs.CandidateId == Id)
                .Select(cs => cs.SkillId)
                .ToList();

            var offers = _dbContext.Offers
                .Include(o => o.OfferSkills)
                .ThenInclude(os => os.Skill)
                .Where(o => o.OfferSkills.Any(os => candidateSkillIds.Contains(os.SkillId))).Include(a=>a.Company)
                .ToList();

            return offers;
        }

        public List<Offer> GetOffersByName(string? job)
        {
            {
                if (string.IsNullOrWhiteSpace(job))
                {
                    return _dbContext.Offers.ToList();
                }

                return _dbContext.Offers
                .Where(o => o.Job.ToLower().Contains(job.ToLower()))
                .ToList();
            }
        }


        public Offer UpdateOffer(int Id, Offer offer)
        {
            Offer? UpdateOffer = _dbContext.Offers.Find(Id);

            if (UpdateOffer != null)
            {

                UpdateOffer.Job = offer.Job;
                UpdateOffer.Description = offer.Description;
                _dbContext.SaveChanges();
                return UpdateOffer;
                
            }
            else
            {
                throw new Exception("Offer not found");
            }
        
        }// actualizar oferta
    }
}