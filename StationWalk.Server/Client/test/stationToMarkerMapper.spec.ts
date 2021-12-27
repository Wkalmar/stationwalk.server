import 'jasmine'
import { Branch, Station } from './../src/models/station';
import { StationToMarkerMapper } from './../src/business-logic/stationToMarkerMapper';
import { LocalizableString } from '../src/models/localizableString';

describe('StationToMarkerMapper', () => {
  it('should map point to marker correctly', () => {
    const station: Station = new Station();
    station.location = {
      lattitude: 58,
      longitude: 42
    };
    station.name = new LocalizableString();
    station.name.en = 'Obolon';
    station.name.ua = 'Оболонь';
    station.branch = Branch.Blue;
    const mapper: StationToMarkerMapper = new StationToMarkerMapper();
    const result = mapper.map(station);
    const resultLatLng = result.getLatLng();
    expect(resultLatLng.lat).toBe(58);
    expect(resultLatLng.lng).toBe(42);
    expect(result.title).toBe('Obolon');
    expect(result.icon).toBe('../assets/blue.png')
  })

  it('should map point to marker correctly 2', () => {
    const station: Station = new Station();
    station.location = {
      lattitude: 13,
      longitude: 16
    }
    station.name = new LocalizableString();
    station.name.en = 'Shulyavska';
    station.name.ua = 'Шулявська';
    station.branch = Branch.Red;
    const mapper: StationToMarkerMapper = new StationToMarkerMapper();
    const result = mapper.map(station);
    const resultLatLng = result.getLatLng();
    expect(resultLatLng.lat).toBe(13);
    expect(resultLatLng.lng).toBe(16);
    expect(result.title).toBe('Shulyavska');
    expect(result.icon).toBe('../assets/red.png')
  })
})