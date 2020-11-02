var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            productId: 0,
            description: "Size",
            qty: 1.55
        }
    },
    mounted() {
        this.getStock();
    },
    mewthods: {
        getStock() {
            this.loading = true;
            axios.get('/Admin/stock')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {

        },
        addStock() {
            this.loading = true;
            axios.get('/Admin/stocks/', this.newStock)
                .then(res => {
                    console.log(res);
                    this.products.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.Id;
        }
    }
})