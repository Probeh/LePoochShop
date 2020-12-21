'use strict';


customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`
        <nav>
            <ul class="list">
                <li class="title">
                    <a href="index.html" data-type="index-link">LePooch</a>
                </li>

                <li class="divider"></li>
                ${ isNormalMode ? `<div id="book-search-input" role="search"><input type="text" placeholder="Type to search"></div>` : '' }
                <li class="chapter">
                    <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
                    <ul class="links">
                        <li class="link">
                            <a href="overview.html" data-type="chapter-link">
                                <span class="icon ion-ios-keypad"></span>Overview
                            </a>
                        </li>
                        <li class="link">
                            <a href="index.html" data-type="chapter-link">
                                <span class="icon ion-ios-paper"></span>README
                            </a>
                        </li>
                                <li class="link">
                                    <a href="dependencies.html" data-type="chapter-link">
                                        <span class="icon ion-ios-list"></span>Dependencies
                                    </a>
                                </li>
                    </ul>
                </li>
                    <li class="chapter modules">
                        <a data-type="chapter-link" href="modules.html">
                            <div class="menu-toggler linked" data-toggle="collapse" ${ isNormalMode ?
                                'data-target="#modules-links"' : 'data-target="#xs-modules-links"' }>
                                <span class="icon ion-ios-archive"></span>
                                <span class="link-name">Modules</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                        </a>
                        <ul class="links collapse " ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                            <li class="link">
                                <a href="modules/AppModule.html" data-type="entity-link">AppModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-AppModule-f0986ad30a4d225ab216b2502aef3004"' : 'data-target="#xs-components-links-module-AppModule-f0986ad30a4d225ab216b2502aef3004"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AppModule-f0986ad30a4d225ab216b2502aef3004"' :
                                            'id="xs-components-links-module-AppModule-f0986ad30a4d225ab216b2502aef3004"' }>
                                            <li class="link">
                                                <a href="components/AppComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">AppComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/AppRoutingModule.html" data-type="entity-link">AppRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/IdentityModule.html" data-type="entity-link">IdentityModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' : 'data-target="#xs-components-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' :
                                            'id="xs-components-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' }>
                                            <li class="link">
                                                <a href="components/IdentityComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">IdentityComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/LoginComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">LoginComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/RegisterComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">RegisterComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                        'data-target="#injectables-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' : 'data-target="#xs-injectables-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' }>
                                        <span class="icon ion-md-arrow-round-down"></span>
                                        <span>Injectables</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="injectables-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' :
                                        'id="xs-injectables-links-module-IdentityModule-dba7288c0921262a1907d1ee7865d172"' }>
                                        <li class="link">
                                            <a href="injectables/UserFormService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>UserFormService</a>
                                        </li>
                                    </ul>
                                </li>
                            </li>
                            <li class="link">
                                <a href="modules/IdentityRoutingModule.html" data-type="entity-link">IdentityRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/ScheduleModule.html" data-type="entity-link">ScheduleModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' : 'data-target="#xs-components-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' :
                                            'id="xs-components-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' }>
                                            <li class="link">
                                                <a href="components/AppointmentFormComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">AppointmentFormComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/AppointmentListComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">AppointmentListComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/AppointmentViewComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">AppointmentViewComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/ScheduleComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">ScheduleComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                        'data-target="#injectables-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' : 'data-target="#xs-injectables-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' }>
                                        <span class="icon ion-md-arrow-round-down"></span>
                                        <span>Injectables</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="injectables-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' :
                                        'id="xs-injectables-links-module-ScheduleModule-cf71a94de5b595d9f30f4007ae84aaec"' }>
                                        <li class="link">
                                            <a href="injectables/AppointmentFormService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>AppointmentFormService</a>
                                        </li>
                                    </ul>
                                </li>
                            </li>
                            <li class="link">
                                <a href="modules/ScheduleRoutingModule.html" data-type="entity-link">ScheduleRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/SharedModule.html" data-type="entity-link">SharedModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' : 'data-target="#xs-components-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' :
                                            'id="xs-components-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' }>
                                            <li class="link">
                                                <a href="components/AboutComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">AboutComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/HomeComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">HomeComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/NavigationComponent.html"
                                                    data-type="entity-link" data-context="sub-entity" data-context-id="modules">NavigationComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                        'data-target="#injectables-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' : 'data-target="#xs-injectables-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' }>
                                        <span class="icon ion-md-arrow-round-down"></span>
                                        <span>Injectables</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="injectables-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' :
                                        'id="xs-injectables-links-module-SharedModule-85a9ae3f92388c05a0fa4febe98cd1c7"' }>
                                        <li class="link">
                                            <a href="injectables/IdentityService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>IdentityService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/LoggerService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>LoggerService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/MessageService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>MessageService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/ScheduleService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>ScheduleService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/StorageService.html"
                                                data-type="entity-link" data-context="sub-entity" data-context-id="modules" }>StorageService</a>
                                        </li>
                                    </ul>
                                </li>
                            </li>
                </ul>
                </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#components-links"' :
                            'data-target="#xs-components-links"' }>
                            <span class="icon ion-md-cog"></span>
                            <span>Components</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="components-links"' : 'id="xs-components-links"' }>
                            <li class="link">
                                <a href="components/AppointmentFormComponent.html" data-type="entity-link">AppointmentFormComponent</a>
                            </li>
                            <li class="link">
                                <a href="components/AppointmentListComponent.html" data-type="entity-link">AppointmentListComponent</a>
                            </li>
                            <li class="link">
                                <a href="components/AppointmentViewComponent.html" data-type="entity-link">AppointmentViewComponent</a>
                            </li>
                            <li class="link">
                                <a href="components/LoginComponent.html" data-type="entity-link">LoginComponent</a>
                            </li>
                            <li class="link">
                                <a href="components/RegisterComponent.html" data-type="entity-link">RegisterComponent</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#classes-links"' :
                            'data-target="#xs-classes-links"' }>
                            <span class="icon ion-ios-paper"></span>
                            <span>Classes</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="classes-links"' : 'id="xs-classes-links"' }>
                            <li class="link">
                                <a href="classes/Account.html" data-type="entity-link">Account</a>
                            </li>
                            <li class="link">
                                <a href="classes/AppSettings.html" data-type="entity-link">AppSettings</a>
                            </li>
                            <li class="link">
                                <a href="classes/Identity.html" data-type="entity-link">Identity</a>
                            </li>
                            <li class="link">
                                <a href="classes/LoggerModel.html" data-type="entity-link">LoggerModel</a>
                            </li>
                            <li class="link">
                                <a href="classes/ModelBase.html" data-type="entity-link">ModelBase</a>
                            </li>
                            <li class="link">
                                <a href="classes/Profile.html" data-type="entity-link">Profile</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#injectables-links"' :
                                'data-target="#xs-injectables-links"' }>
                                <span class="icon ion-md-arrow-round-down"></span>
                                <span>Injectables</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                            <ul class="links collapse " ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                                <li class="link">
                                    <a href="injectables/AppointmentFormService.html" data-type="entity-link">AppointmentFormService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/IdentityService.html" data-type="entity-link">IdentityService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/LoggerService.html" data-type="entity-link">LoggerService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/MessageService.html" data-type="entity-link">MessageService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ScheduleService.html" data-type="entity-link">ScheduleService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/StorageService.html" data-type="entity-link">StorageService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/UserFormService.html" data-type="entity-link">UserFormService</a>
                                </li>
                            </ul>
                        </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#interceptors-links"' :
                            'data-target="#xs-interceptors-links"' }>
                            <span class="icon ion-ios-swap"></span>
                            <span>Interceptors</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="interceptors-links"' : 'id="xs-interceptors-links"' }>
                            <li class="link">
                                <a href="interceptors/RequestInterceptor.html" data-type="entity-link">RequestInterceptor</a>
                            </li>
                            <li class="link">
                                <a href="interceptors/TokenInterceptor.html" data-type="entity-link">TokenInterceptor</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#guards-links"' :
                            'data-target="#xs-guards-links"' }>
                            <span class="icon ion-ios-lock"></span>
                            <span>Guards</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="guards-links"' : 'id="xs-guards-links"' }>
                            <li class="link">
                                <a href="guards/IdentityGuard.html" data-type="entity-link">IdentityGuard</a>
                            </li>
                            <li class="link">
                                <a href="guards/IdentityResolver.html" data-type="entity-link">IdentityResolver</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#interfaces-links"' :
                            'data-target="#xs-interfaces-links"' }>
                            <span class="icon ion-md-information-circle-outline"></span>
                            <span>Interfaces</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? ' id="interfaces-links"' : 'id="xs-interfaces-links"' }>
                            <li class="link">
                                <a href="interfaces/IEndpoint.html" data-type="entity-link">IEndpoint</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/IKeyValue.html" data-type="entity-link">IKeyValue</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ILoggerModel.html" data-type="entity-link">ILoggerModel</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/IModelBase.html" data-type="entity-link">IModelBase</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#miscellaneous-links"'
                            : 'data-target="#xs-miscellaneous-links"' }>
                            <span class="icon ion-ios-cube"></span>
                            <span>Miscellaneous</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="miscellaneous-links"' : 'id="xs-miscellaneous-links"' }>
                            <li class="link">
                                <a href="miscellaneous/enumerations.html" data-type="entity-link">Enums</a>
                            </li>
                            <li class="link">
                                <a href="miscellaneous/typealiases.html" data-type="entity-link">Type aliases</a>
                            </li>
                            <li class="link">
                                <a href="miscellaneous/variables.html" data-type="entity-link">Variables</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <a data-type="chapter-link" href="routes.html"><span class="icon ion-ios-git-branch"></span>Routes</a>
                        </li>
                    <li class="chapter">
                        <a data-type="chapter-link" href="coverage.html"><span class="icon ion-ios-stats"></span>Documentation coverage</a>
                    </li>
            </ul>
        </nav>
        `);
        this.innerHTML = tp.strings;
    }
});