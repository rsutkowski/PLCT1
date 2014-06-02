var MyModel = function () {
    var dataRootUrl = "/api/message";
    var self = this;
    self.isLoaded = ko.observable(false);
    self.isLoading = ko.observable(false);
    self.items = ko.observableArray();
    self.sortByStars = ko.observable(true);
    self.newMessage = ko.observable('');
    self.starredFilter = ko.observable(false);
    self.unstarredFilter = ko.observable(false);
    self.filterValue = ko.observable('All');

    self.getLoadUrl = function () {
        if (self.filterValue() == 'Starred')
            return dataRootUrl + '/starred';
        if (self.filterValue() == 'Unstarred')
            return dataRootUrl + "/unstarred";
        return dataRootUrl;

    }

    self.postNew = function () {

        $.ajax(dataRootUrl + '?message=' + self.newMessage(), {
            type: "POST",
            cache: false,
        }).done(function () {
            self.newMessage("");
            self.loadData();
        });

    };



    self.loadData = function () {
        this.isLoading(true);
        this.isLoaded(false);

        var url = self.getLoadUrl();

        // Setting a timeout so the loading text is visible in the sample
        setTimeout(function () {
            $.ajax(url, {
                type: "GET",
                cache: false,
            }).done(function (data) {
                self.items(data);
                self.isLoaded(true);
                self.isLoading(false);
            });
        }, 1000);
    };

    self.deleteMessage = function (item) {
        $.ajax(dataRootUrl + '/' + item.MessageId, {
            type: "DELETE",
            cache: false
        }).done(function () {
            self.loadData();
        });
    };

    self.starMessage = function (item) {
        setTimeout(function () {
            $.ajax(dataRootUrl + "/" + item.MessageId + "/star/", {
                type: "POST",
                cache: false,
            }).done(function () {
                self.loadData();
            });
        }, 1000);
    };
};

var viewModel = new MyModel();
ko.applyBindings(viewModel);
viewModel.loadData();