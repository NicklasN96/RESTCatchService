using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTCatchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //Liste med catches
        public static List<Catch> CatchList = new List<Catch>()
        {
            new Catch(1, "EbbeVand", "Gedde", 3.75, "Aresø", 2),
            new Catch(2, "PeterStor", "Ørred", 1.55, "Emsø", 7),
            new Catch(3,"AndyBor","Skalle",0.35,"Vejlesø",25)
        };

        //Get All catches
        public IList<Catch> GetCatches()
        {
            return CatchList;
        }

        //Get one catch
        public Catch GetOneCatch(string id)
        {
            int idInt = int.Parse(id);
            return CatchList.FirstOrDefault((newCatch => newCatch.id == idInt));
        }

    
        //Add Catch
        public Catch AddCatch(Catch newCatch)
        {
            
            CatchList.Add(newCatch);
            return newCatch;
        }

        //Delete Catch
        public Catch DeleteCatch(string id)
        {
            Catch newCatch = GetOneCatch(id);
            if (newCatch == null) return null;
            CatchList.Remove(newCatch);
            return newCatch;
        }

        //Update Catch
        public Catch UpdateCatch(string id, Catch newCatch)
        {
            Catch oldCatch = DeleteCatch(id);
            if (oldCatch != null)
            {
                newCatch.id = oldCatch.id;
                CatchList.Add(newCatch);
            }
            return GetOneCatch(id);
        }




        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

