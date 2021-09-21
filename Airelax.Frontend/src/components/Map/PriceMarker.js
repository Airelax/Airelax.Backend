const createHTMLMapMarker = ({OverlayView = window.google.maps.OverlayView, ...args}) => {
    class HTMLMapMarker extends OverlayView {
        constructor() {
            super();
            this.latlng = args.latlng;
            this.html = args.html;
            this.setMap(args.map);

        }

        createDiv() {
            this.div = document.createElement('div');
            this.div.classList.add('suck');
            this.div.style.position = 'absolute';
            this.div.style.zIndex = '150';
            if (this.html) {
                this.div.innerHTML = this.html;
            }
            window.google.maps.event.addDomListener(this.div, 'click', () => {
                window.google.maps.event.trigger(this, 'click');
            });

        }

        appendDivToOverlay() {
            const panes = this.getPanes();
            panes.overlayLayer.appendChild(this.div);
        }

        positionDiv() {
            const point = this.getProjection().fromLatLngToDivPixel(this.latlng);
            if (point) {
                this.div.style.left = `${point.x}px`;
                this.div.style.top = `${point.y}px`;
            }
        }

        draw() {
            if (!this.div) {
                this.createDiv();

                this.appendDivToOverlay();

            }
            this.positionDiv();
        }

        remove() {
            if (this.div) {
                this.div.parentNode.removeChild(this.div);
                this.div = null;
            }
        }

        getPosition() {
            return this.latlng;
        }

        getDraggable() {
            return false;
        }
    }

    return new HTMLMapMarker();
};

export default createHTMLMapMarker;