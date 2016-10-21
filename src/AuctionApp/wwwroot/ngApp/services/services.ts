namespace AuctionApp.Services {
    export class ItemService {
        private itemsResource

        constructor(
            $resource: ng.resource.IResourceService) {

            this.itemsResource = $resource(
                '/api/items', {}, 
                {
                    withBids:
                    {
                        method: 'GET',
                        url: '/api/items/withBids',
                        isArray: true
                    },
                    addBid: {
                        method: 'POST',
                        url: '/api/items/addBid'
                    },
                    getItem: {
                        method: 'GET',
                        url: '/api/items/:id'
                    }
               }
            );
        }

        public listItems() {

            return this.itemsResource.query();
        }

        public listItemsWithBids() {
            return this.itemsResource.withBids();
        }
        public addBid(bid) {
           console.log(bid.itemId)
           return this.itemsResource.addBid(bid)
            
        }
        public getItem(id: number) {
            return this.itemsResource.getItem({ id: id }).$promise;
        }
    }
    angular.module("AuctionApp").service("itemService", ItemService);
}
