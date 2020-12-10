import { Provider } from '@assets/enums/providers.enum';
import { Endpoints } from '@assets/helpers/endpoint.interface';

const endpoints: Endpoints = {
  [Provider.Server]: {

  }
}

export const environment = {
  production: false,
  endpoints: endpoints
};

