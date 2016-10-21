namespace AuctionApp.Controllers {

    export class HomeController {
        public items;

        constructor(private itemService: AuctionApp.Services.ItemService) {
            this.items = itemService.listItemsWithBids()
        }
    }

    export class ItemsController {
        public newBid = {};
        public item;
        constructor(private itemService: AuctionApp.Services.ItemService,
            private $stateParams:ng.ui.IStateParamsService) {
            this.newBid["itemId"] = $stateParams["id"]

            itemService.getItem($stateParams["id"]).then((item) => {
                this.item = item;
            });
        }
        public addBid() {
            console.log(this.newBid, this.$stateParams)
            this.itemService.addBid(this.newBid)
        }
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }
}
