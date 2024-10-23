import { Review } from "./review";

export interface Campground {
    id: number;
    title: string;
    price: string;
    description: string;
    location: string;
    image: string;

    reviews: Review[];
}