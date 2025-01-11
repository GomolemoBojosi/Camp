import { Campground } from "./campground";

export interface Review {
    id: number;
    body: string;
    rating: number;
    campgroundId: number;
}