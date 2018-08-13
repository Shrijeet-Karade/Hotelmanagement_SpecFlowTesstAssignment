using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        
        private List<Hotel> hotels = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }
        [Given(@"User provided valid Id (.*) for hotel")]
        public void GivenUserProvidedValidIdForHotel(int id)
        {
            hotel.Id = id;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUserHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [When(@"User calls AddHotel api")]
        [Given(@"User has called AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {

            hotels = HotelsApiCaller.AddHotel(hotel);
        }

       
        [When(@"User calls GetHotelById api and passes Id'(.*)'")]
        public void WhenUserCallsGetHotelByIdApiAndPassesId(int id)
        {
            hotel = HotelsApiCaller.GetHotelById(id);

        }


        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
        }
        [Then(@"Then Hotel with name '(.*)' and '(.*)' should be present in the response")]
        public void ThenThenHotelWithNameAndShouldBePresentInTheResponse(string name, string name1)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name1.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name1 {0} not found in response", name1));
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
