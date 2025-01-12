using System;
using CoreFoundation;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using WebKit;

namespace YandexMetricaIOS
{
	// typedef void (^YMMAppMetricaDeviceIDRetrievingBlock)(NSString * _Nullable, NSError * _Nullable);
	delegate void YMMAppMetricaDeviceIDRetrievingBlock ([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	[Static]
	public interface Constants
	{
		//TODO Dont find with compile project, dont know why
		//extern const NSErrorUserInfoKey _Nonnull YMMBacktraceErrorKey;
		//[Field("kYMMBacktraceErrorKey", "__Internal")]
		//NSString kYMMBacktraceErrorKey { get; }

		[Field("kYMMYandexMetricaErrorDomain", "__Internal")]
		NSString kYMMYandexMetricaErrorDomain { get; }

		// extern NSString *const _Nonnull kYMMPlatformNative;
		[Field("kYMMPlatformNative", "__Internal")]
		NSString kYMMPlatformNative { get; }

		// extern NSString *const _Nonnull kYMMPlatformFlutter;
		[Field("kYMMPlatformFlutter", "__Internal")]
		NSString kYMMPlatformFlutter { get; }

		// extern NSString *const _Nonnull kYMMPlatformUnity;
		[Field("kYMMPlatformUnity", "__Internal")]
		NSString kYMMPlatformUnity { get; }

		// extern NSString *const _Nonnull kYMMPlatformReactNative;
		[Field("kYMMPlatformReactNative", "__Internal")]
		NSString kYMMPlatformReactNative { get; }

		// extern NSString *const _Nonnull kYMMPlatformXamarin;
		[Field("kYMMPlatformXamarin", "__Internal")]
		NSString kYMMPlatformXamarin { get; }

		// extern NSString *const _Nonnull kYMMPlatformCordova;
		[Field("kYMMPlatformCordova", "__Internal")]
		NSString kYMMPlatformCordova { get; }
    }

	// @protocol YMMErrorRepresentable <NSObject>
	[Model, Protocol]
	[BaseType (typeof(NSObject))]
	interface YMMErrorRepresentable
	{
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Abstract]
		[Export ("identifier")]
		string Identifier { get; }

		// @optional @property (readonly, copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; }

		// @optional @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable parameters;
		[NullAllowed, Export ("parameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Parameters { get; }

		// @optional @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable backtrace;
		[NullAllowed, Export ("backtrace", ArgumentSemantic.Copy)]
		NSNumber[] Backtrace { get; }

		// @optional @property (readonly, nonatomic, strong) id<YMMErrorRepresentable> _Nullable underlyingError;
		[NullAllowed, Export ("underlyingError", ArgumentSemantic.Strong)]
		YMMErrorRepresentable UnderlyingError { get; }
	}

	// @interface YMMYandexMetrica : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetrica
	{
		// +(void)activateWithConfiguration:(YMMYandexMetricaConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("activateWithConfiguration:")]
		void ActivateWithConfiguration (YMMYandexMetricaConfiguration configuration);

		// +(void)reportEvent:(NSString * _Nonnull)message onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportEvent:onFailure:")]
		void ReportEvent (string message, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportEvent:(NSString * _Nonnull)message parameters:(NSDictionary * _Nullable)params onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportEvent:parameters:onFailure:")]
		void ReportEvent (string message, [NullAllowed] NSDictionary @params, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportError:(NSString * _Nonnull)message exception:(NSException * _Nullable)exception onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((deprecated("Use reportError:options:onFailure: or reportNSError:options:onFailure:")));
		[Static]
		[Export ("reportError:exception:onFailure:")]
		void ReportError (string message, [NullAllowed] NSException exception, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportNSError:(NSError * _Nonnull)error onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(nserror:onFailure:)")));
		[Static]
		[Export ("reportNSError:onFailure:")]
		void ReportNSError (NSError error, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportNSError:(NSError * _Nonnull)error options:(YMMErrorReportingOptions)options onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(nserror:options:onFailure:)")));
		[Static]
		[Export ("reportNSError:options:onFailure:")]
		void ReportNSError (NSError error, YMMErrorReportingOptions options, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportError:(id<YMMErrorRepresentable> _Nonnull)error onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(error:onFailure:)")));
		[Static]
		[Export ("reportError:onFailure:")]
		void ReportError (YMMErrorRepresentable error, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportError:(id<YMMErrorRepresentable> _Nonnull)error options:(YMMErrorReportingOptions)options onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(error:options:onFailure:)")));
		[Static]
		[Export ("reportError:options:onFailure:")]
		void ReportError (YMMErrorRepresentable error, YMMErrorReportingOptions options, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportUserProfile:(YMMUserProfile * _Nonnull)userProfile onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportUserProfile:onFailure:")]
		void ReportUserProfile (YMMUserProfile userProfile, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportRevenue:(YMMRevenueInfo * _Nonnull)revenueInfo onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportRevenue:onFailure:")]
		void ReportRevenue (YMMRevenueInfo revenueInfo, [NullAllowed] Action<NSError> onFailure);

		// +(void)setUserProfileID:(NSString * _Nullable)userProfileID;
		[Static]
		[Export ("setUserProfileID:")]
		void SetUserProfileID ([NullAllowed] string userProfileID);

		// +(void)setStatisticsSending:(BOOL)enabled;
		[Static]
		[Export ("setStatisticsSending:")]
		void SetStatisticsSending (bool enabled);

		// +(void)setLocationTracking:(BOOL)enabled;
		[Static]
		[Export ("setLocationTracking:")]
		void SetLocationTracking (bool enabled);

		// +(void)setLocation:(CLLocation * _Nullable)location;
		[Static]
		[Export ("setLocation:")]
		void SetLocation ([NullAllowed] CLLocation location);

		// +(NSString * _Nonnull)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		string LibraryVersion { get; }

		// +(void)requestAppMetricaDeviceIDWithCompletionQueue:(dispatch_queue_t _Nullable)queue completionBlock:(YMMAppMetricaDeviceIDRetrievingBlock _Nonnull)block;
		[Static]
		[Export ("requestAppMetricaDeviceIDWithCompletionQueue:completionBlock:")]
		void RequestAppMetricaDeviceIDWithCompletionQueue ([NullAllowed] DispatchQueue queue, YMMAppMetricaDeviceIDRetrievingBlock block);

		// +(BOOL)handleOpenURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		// +(void)activateReporterWithConfiguration:(YMMReporterConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("activateReporterWithConfiguration:")]
		void ActivateReporterWithConfiguration (YMMReporterConfiguration configuration);

		// +(id<YMMYandexMetricaReporting> _Nullable)reporterForApiKey:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("reporterForApiKey:")]
		[return: NullAllowed]
		YMMYandexMetricaReporting ReporterForApiKey (string apiKey);

		// +(void)reportReferralUrl:(NSURL * _Nonnull)url;
		[Static]
		[Export ("reportReferralUrl:")]
		void ReportReferralUrl (NSUrl url);

		// +(void)sendEventsBuffer;
		[Static]
		[Export ("sendEventsBuffer")]
		void SendEventsBuffer ();

		// +(void)resumeSession;
		[Static]
		[Export ("resumeSession")]
		void ResumeSession ();

		// +(void)pauseSession;
		[Static]
		[Export ("pauseSession")]
		void PauseSession ();

		// +(void)setErrorEnvironmentValue:(NSString * _Nullable)value forKey:(NSString * _Nonnull)key;
		[Static]
		[Export ("setErrorEnvironmentValue:forKey:")]
		void SetErrorEnvironmentValue ([NullAllowed] string value, string key);

		// +(void)reportECommerce:(YMMECommerce * _Nonnull)eCommerce onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(eCommerce:onFailure:)")));
		[Static]
		[Export ("reportECommerce:onFailure:")]
		void ReportECommerce (YMMECommerce eCommerce, [NullAllowed] Action<NSError> onFailure);

		// +(void)initWebViewReporting:(WKUserContentController * _Nonnull)userContentController onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("initWebViewReporting:onFailure:")]
		void InitWebViewReporting (WKUserContentController userContentController, [NullAllowed] Action<NSError> onFailure);

		// +(id<YMMYandexMetricaPlugins> _Nonnull)getPluginExtension;
		[Static]
		[Export ("getPluginExtension")]
		YMMYandexMetricaPlugins PluginExtension { get; }

		// +(void)reportAdRevenue:(YMMAdRevenueInfo * _Nonnull)adRevenue onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(adRevenue:onFailure:)")));
		[Static]
		[Export ("reportAdRevenue:onFailure:")]
		void ReportAdRevenue (YMMAdRevenueInfo adRevenue, [NullAllowed] Action<NSError> onFailure);
	}

	// @interface YMMYandexMetricaConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaConfiguration
	{
		// -(instancetype _Nullable)initWithApiKey:(NSString * _Nonnull)apiKey;
		[Export ("initWithApiKey:")]
		IntPtr Constructor (string apiKey);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (assign, nonatomic) BOOL handleFirstActivationAsUpdate;
		[Export ("handleFirstActivationAsUpdate")]
		bool HandleFirstActivationAsUpdate { get; set; }

		// @property (assign, nonatomic) BOOL handleActivationAsSessionStart;
		[Export ("handleActivationAsSessionStart")]
		bool HandleActivationAsSessionStart { get; set; }

		// @property (assign, nonatomic) BOOL sessionsAutoTracking;
		[Export ("sessionsAutoTracking")]
		bool SessionsAutoTracking { get; set; }

		// @property (assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; set; }

		// @property (assign, nonatomic) NSUInteger maxReportsInDatabaseCount;
		[Export ("maxReportsInDatabaseCount")]
		nuint MaxReportsInDatabaseCount { get; set; }

		// @property (assign, nonatomic) BOOL locationTracking;
		[Export ("locationTracking")]
		bool LocationTracking { get; set; }

		// @property (nonatomic, strong) CLLocation * _Nullable location;
		[NullAllowed, Export ("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; set; }

		// @property (assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; set; }

		// @property (assign, nonatomic) BOOL crashReporting;
		[Export ("crashReporting")]
		bool CrashReporting { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable appVersion;
		[NullAllowed, Export ("appVersion")]
		string AppVersion { get; set; }

		// @property (assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; set; }

		// @property (assign, nonatomic) BOOL appForKids __attribute__((deprecated("")));
		[Export ("appForKids")]
		bool AppForKids { get; set; }

		// @property (copy, nonatomic) YMMYandexMetricaPreloadInfo * _Nullable preloadInfo;
		[NullAllowed, Export ("preloadInfo", ArgumentSemantic.Copy)]
		YMMYandexMetricaPreloadInfo PreloadInfo { get; set; }

		// @property (assign, nonatomic) BOOL revenueAutoTrackingEnabled;
		[Export ("revenueAutoTrackingEnabled")]
		bool RevenueAutoTrackingEnabled { get; set; }

		// @property (assign, nonatomic) BOOL appOpenTrackingEnabled;
		[Export ("appOpenTrackingEnabled")]
		bool AppOpenTrackingEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userProfileID;
		[NullAllowed, Export ("userProfileID")]
		string UserProfileID { get; set; }
	}

	// @interface YMMReporterConfiguration : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMReporterConfiguration : INSCopying, INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable apiKey;
		[NullAllowed, Export ("apiKey")]
		string ApiKey { get; }

		// @property (readonly, assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; }

		// @property (readonly, assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxReportsInDatabaseCount;
		[Export ("maxReportsInDatabaseCount")]
		nuint MaxReportsInDatabaseCount { get; }

		// @property (readonly, assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable userProfileID;
		[NullAllowed, Export ("userProfileID")]
		string UserProfileID { get; }

		// -(instancetype _Nullable)initWithApiKey:(NSString * _Nonnull)apiKey;
		[Export ("initWithApiKey:")]
		IntPtr Constructor (string apiKey);
	}

	// @interface YMMMutableReporterConfiguration : YMMReporterConfiguration
	[BaseType (typeof(YMMReporterConfiguration))]
	[DisableDefaultCtor]
	interface YMMMutableReporterConfiguration
	{
		// @property (assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; set; }

		// @property (assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; set; }

		// @property (assign, nonatomic) NSUInteger maxReportsInDatabaseCount;
		[Export ("maxReportsInDatabaseCount")]
		nuint MaxReportsInDatabaseCount { get; set; }

		// @property (assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userProfileID;
		[NullAllowed, Export ("userProfileID")]
		string UserProfileID { get; set; }
	}

	// @protocol YMMYandexMetricaReporting <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetricaReporting
	{
		// @required -(void)reportEvent:(NSString * _Nonnull)name onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportEvent:onFailure:")]
		void ReportEvent (string name, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportEvent:(NSString * _Nonnull)name parameters:(NSDictionary * _Nullable)params onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportEvent:parameters:onFailure:")]
		void ReportEvent (string name, [NullAllowed] NSDictionary @params, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(NSString * _Nonnull)name exception:(NSException * _Nullable)exception onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((deprecated("Use reportError:options:onFailure: or reportNSError:options:onFailure:")));
		[Abstract]
		[Export ("reportError:exception:onFailure:")]
		void ReportError (string name, [NullAllowed] NSException exception, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportNSError:(NSError * _Nonnull)error onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(nserror:onFailure:)")));
		[Abstract]
		[Export ("reportNSError:onFailure:")]
		void ReportNSError (NSError error, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportNSError:(NSError * _Nonnull)error options:(YMMErrorReportingOptions)options onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(nserror:options:onFailure:)")));
		[Abstract]
		[Export ("reportNSError:options:onFailure:")]
		void ReportNSError (NSError error, YMMErrorReportingOptions options, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(id<YMMErrorRepresentable> _Nonnull)error onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(error:onFailure:)")));
		[Abstract]
		[Export ("reportError:onFailure:")]
		void ReportError (YMMErrorRepresentable error, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(id<YMMErrorRepresentable> _Nonnull)error options:(YMMErrorReportingOptions)options onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(error:options:onFailure:)")));
		[Abstract]
		[Export ("reportError:options:onFailure:")]
		void ReportError (YMMErrorRepresentable error, YMMErrorReportingOptions options, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportUserProfile:(YMMUserProfile * _Nonnull)userProfile onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportUserProfile:onFailure:")]
		void ReportUserProfile (YMMUserProfile userProfile, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportRevenue:(YMMRevenueInfo * _Nonnull)revenueInfo onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportRevenue:onFailure:")]
		void ReportRevenue (YMMRevenueInfo revenueInfo, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)setUserProfileID:(NSString * _Nullable)userProfileID;
		[Abstract]
		[Export ("setUserProfileID:")]
		void SetUserProfileID ([NullAllowed] string userProfileID);

		// @required -(void)resumeSession;
		[Abstract]
		[Export ("resumeSession")]
		void ResumeSession ();

		// @required -(void)pauseSession;
		[Abstract]
		[Export ("pauseSession")]
		void PauseSession ();

		// @required -(void)setStatisticsSending:(BOOL)enabled;
		[Abstract]
		[Export ("setStatisticsSending:")]
		void SetStatisticsSending (bool enabled);

		// @required -(void)sendEventsBuffer;
		[Abstract]
		[Export ("sendEventsBuffer")]
		void SendEventsBuffer ();

		// @required -(void)reportECommerce:(YMMECommerce * _Nonnull)eCommerce onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(eCommerce:onFailure:)")));
		[Abstract]
		[Export ("reportECommerce:onFailure:")]
		void ReportECommerce (YMMECommerce eCommerce, [NullAllowed] Action<NSError> onFailure);

		// @required -(id<YMMYandexMetricaPluginReporting> _Nonnull)getPluginExtension;
		[Abstract]
		[Export ("getPluginExtension")]
		YMMYandexMetricaPluginReporting PluginExtension { get; }

		// @required -(void)reportAdRevenue:(YMMAdRevenueInfo * _Nonnull)adRevenue onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("report(adRevenue:onFailure:)")));
		[Abstract]
		[Export ("reportAdRevenue:onFailure:")]
		void ReportAdRevenue (YMMAdRevenueInfo adRevenue, [NullAllowed] Action<NSError> onFailure);
	}

	// @protocol YMMYandexMetricaPluginReporting <NSObject>
	[Model,Protocol]
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetricaPluginReporting
	{
		// @required -(void)reportUnhandledException:(YMMPluginErrorDetails * _Nonnull)errorDetails onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportUnhandledException(exception:onFailure:)")));
		[Abstract]
		[Export ("reportUnhandledException:onFailure:")]
		void ReportUnhandledException (YMMPluginErrorDetails errorDetails, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(YMMPluginErrorDetails * _Nonnull)errorDetails message:(NSString * _Nullable)message onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportError(error:message:onFailure:)")));
		[Abstract]
		[Export ("reportError:message:onFailure:")]
		void ReportError (YMMPluginErrorDetails errorDetails, [NullAllowed] string message, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportErrorWithIdentifier:(NSString * _Nonnull)identifier message:(NSString * _Nullable)message details:(YMMPluginErrorDetails * _Nullable)errorDetails onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportError(identifier:message:error:onFailure:)")));
		[Abstract]
		[Export ("reportErrorWithIdentifier:message:details:onFailure:")]
		void ReportErrorWithIdentifier (string identifier, [NullAllowed] string message, [NullAllowed] YMMPluginErrorDetails errorDetails, [NullAllowed] Action<NSError> onFailure);
	}

	// @interface YMMYandexMetricaPreloadInfo : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaPreloadInfo : INSCopying
	{
		// -(instancetype _Nullable)initWithTrackingIdentifier:(NSString * _Nonnull)trackingID;
		[Export ("initWithTrackingIdentifier:")]
		IntPtr Constructor (string trackingID);

		// -(void)setAdditionalInfo:(NSString * _Nonnull)info forKey:(NSString * _Nonnull)key;
		[Export ("setAdditionalInfo:forKey:")]
		void SetAdditionalInfo (string info, string key);
	}

	// @interface YMMUserProfileUpdate : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMUserProfileUpdate
	{
	}

	// @protocol YMMNameAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IYMMNameAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue ([NullAllowed] string value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMGenderAttribute <NSObject>
	[Protocol, Model(Name = "YMMGenderAttributeNative")]
	[BaseType (typeof(NSObject))]
	interface YMMGenderAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(YMMGenderType)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (YMMGenderType value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMBirthDateAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMBirthDateAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withAge:(NSUInteger)value;
		[Abstract]
		[Export ("withAge:")]
		YMMUserProfileUpdate WithAge (nuint value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year __attribute__((swift_name("withDate(year:)")));
		[Abstract]
		[Export ("withYear:")]
		YMMUserProfileUpdate WithYear (nuint year);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year month:(NSUInteger)month __attribute__((swift_name("withDate(year:month:)")));
		[Abstract]
		[Export ("withYear:month:")]
		YMMUserProfileUpdate WithYear (nuint year, nuint month);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year month:(NSUInteger)month day:(NSUInteger)day __attribute__((swift_name("withDate(year:month:day:)")));
		[Abstract]
		[Export ("withYear:month:day:")]
		YMMUserProfileUpdate WithYear (nuint year, nuint month, nuint day);

		// @required -(YMMUserProfileUpdate * _Nonnull)withDateComponents:(NSDateComponents * _Nonnull)dateComponents __attribute__((swift_name("withDate(dateComponents:)")));
		[Abstract]
		[Export ("withDateComponents:")]
		YMMUserProfileUpdate WithDateComponents (NSDateComponents dateComponents);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMNotificationsEnabledAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMNotificationsEnabledAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(BOOL)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (bool value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMCustomStringAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IYMMCustomStringAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue ([NullAllowed] string value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined ([NullAllowed] string value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMCustomNumberAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IYMMCustomNumberAttribute
    {
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(double)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (double value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(double)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined (double value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @protocol YMMCustomCounterAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMCustomCounterAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withDelta:(double)value;
		[Abstract]
		[Export ("withDelta:")]
		YMMUserProfileUpdate WithDelta (double value);
	}

	// @protocol YMMCustomBoolAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IYMMCustomBoolAttribute
    {
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(BOOL)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (bool value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(BOOL)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined (bool value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
		[Abstract]
		[Export ("withValueReset")]
		YMMUserProfileUpdate WithValueReset { get; }
	}

	// @interface YMMProfileAttribute : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMProfileAttribute
	{
		// +(id<YMMNameAttribute> _Nonnull)name;
		[Static]
		[Export ("name")]
		IYMMNameAttribute Name { get; }

		// +(id<YMMGenderAttribute> _Nonnull)gender;
		[Static]
		[Export ("gender")]
		YMMGenderAttribute Gender { get; }

		// +(id<YMMBirthDateAttribute> _Nonnull)birthDate;
		[Static]
		[Export ("birthDate")]
		YMMBirthDateAttribute BirthDate { get; }

		// +(id<YMMNotificationsEnabledAttribute> _Nonnull)notificationsEnabled;
		[Static]
		[Export ("notificationsEnabled")]
		YMMNotificationsEnabledAttribute NotificationsEnabled { get; }

		// +(id<YMMCustomStringAttribute> _Nonnull)customString:(NSString * _Nonnull)name;
		[Static]
		[Export ("customString:")]
		IYMMCustomStringAttribute CustomString (string name);

		// +(id<YMMCustomNumberAttribute> _Nonnull)customNumber:(NSString * _Nonnull)name;
		[Static]
		[Export ("customNumber:")]
        IYMMCustomNumberAttribute CustomNumber (string name);

		// +(id<YMMCustomCounterAttribute> _Nonnull)customCounter:(NSString * _Nonnull)name;
		[Static]
		[Export ("customCounter:")]
		YMMCustomCounterAttribute CustomCounter (string name);

		// +(id<YMMCustomBoolAttribute> _Nonnull)customBool:(NSString * _Nonnull)name;
		[Static]
		[Export ("customBool:")]
		IYMMCustomBoolAttribute CustomBool (string name);
	}

	// @interface YMMUserProfile : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	interface YMMUserProfile : INSCopying, INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSArray<YMMUserProfileUpdate *> * _Nonnull updates;
		[Export ("updates", ArgumentSemantic.Copy)]
		YMMUserProfileUpdate[] Updates { get; }

		// -(instancetype _Nonnull)initWithUpdates:(NSArray<YMMUserProfileUpdate *> * _Nonnull)updates;
		[Export ("initWithUpdates:")]
		IntPtr Constructor (YMMUserProfileUpdate[] updates);
	}

	// @interface YMMMutableUserProfile : YMMUserProfile
	[BaseType (typeof(YMMUserProfile))]
	interface YMMMutableUserProfile
	{
		// -(void)apply:(YMMUserProfileUpdate * _Nonnull)update;
		[Export ("apply:")]
		void Apply (YMMUserProfileUpdate update);

		// -(void)applyFromArray:(NSArray<YMMUserProfileUpdate *> * _Nonnull)updatesArray;
		[Export ("applyFromArray:")]
		void ApplyFromArray (YMMUserProfileUpdate[] updatesArray);
	}

	// @interface YMMRevenueInfo : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMRevenueInfo : INSCopying, INSMutableCopying
	{
		// @property (readonly, assign, nonatomic) double price __attribute__((deprecated("Use priceDecimal")));
		[Export ("price")]
		double Price { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable priceDecimal;
		[NullAllowed, Export ("priceDecimal", ArgumentSemantic.Strong)]
		NSDecimalNumber PriceDecimal { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull currency;
		[Export ("currency")]
		string Currency { get; }

		// @property (readonly, assign, nonatomic) NSUInteger quantity;
		[Export ("quantity")]
		nuint Quantity { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable productID;
		[NullAllowed, Export ("productID")]
		string ProductID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transactionID;
		[NullAllowed, Export ("transactionID")]
		string TransactionID { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable receiptData;
		[NullAllowed, Export ("receiptData", ArgumentSemantic.Copy)]
		NSData ReceiptData { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary Payload { get; }

		// -(instancetype _Nonnull)initWithPrice:(double)price currency:(NSString * _Nonnull)currency __attribute__((deprecated("Use initWithPriceDecimal:currency:")));
		[Export ("initWithPrice:currency:")]
		IntPtr Constructor (double price, string currency);

		// -(instancetype _Nonnull)initWithPriceDecimal:(NSDecimalNumber * _Nonnull)priceDecimal currency:(NSString * _Nonnull)currency;
		[Export ("initWithPriceDecimal:currency:")]
		IntPtr Constructor (NSDecimalNumber priceDecimal, string currency);

		// -(instancetype _Nonnull)initWithPrice:(double)price currency:(NSString * _Nonnull)currency quantity:(NSUInteger)quantity productID:(NSString * _Nullable)productID transactionID:(NSString * _Nullable)transactionID receiptData:(NSData * _Nullable)receiptData payload:(NSDictionary * _Nullable)payload __attribute__((deprecated("Use initWithPriceDecimal:...")));
		[Export ("initWithPrice:currency:quantity:productID:transactionID:receiptData:payload:")]
		IntPtr Constructor (double price, string currency, nuint quantity, [NullAllowed] string productID, [NullAllowed] string transactionID, [NullAllowed] NSData receiptData, [NullAllowed] NSDictionary payload);

		// -(instancetype _Nonnull)initWithPriceDecimal:(NSDecimalNumber * _Nonnull)priceDecimal currency:(NSString * _Nonnull)currency quantity:(NSUInteger)quantity productID:(NSString * _Nullable)productID transactionID:(NSString * _Nullable)transactionID receiptData:(NSData * _Nullable)receiptData payload:(NSDictionary * _Nullable)payload;
		[Export ("initWithPriceDecimal:currency:quantity:productID:transactionID:receiptData:payload:")]
		IntPtr Constructor (NSDecimalNumber priceDecimal, string currency, nuint quantity, [NullAllowed] string productID, [NullAllowed] string transactionID, [NullAllowed] NSData receiptData, [NullAllowed] NSDictionary payload);
	}

	// @interface YMMMutableRevenueInfo : YMMRevenueInfo
	[BaseType (typeof(YMMRevenueInfo))]
	interface YMMMutableRevenueInfo
	{
		// @property (assign, nonatomic) NSUInteger quantity;
		[Export ("quantity")]
		nuint Quantity { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull productID;
		[Export ("productID")]
		string ProductID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull transactionID;
		[Export ("transactionID")]
		string TransactionID { get; set; }

		// @property (copy, nonatomic) NSData * _Nonnull receiptData;
		[Export ("receiptData", ArgumentSemantic.Copy)]
		NSData ReceiptData { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull payload;
		[Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary Payload { get; set; }
	}

	// @interface YMMError : NSObject <YMMErrorRepresentable>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMError : YMMErrorRepresentable
	{
		// +(instancetype _Nonnull)errorWithIdentifier:(NSString * _Nonnull)identifier;
		[Static]
		[Export ("errorWithIdentifier:")]
		YMMError ErrorWithIdentifier (string identifier);

		// +(instancetype _Nonnull)errorWithIdentifier:(NSString * _Nonnull)identifier message:(NSString * _Nullable)message parameters:(NSDictionary<NSString *,id> * _Nullable)parameters;
		[Static]
		[Export ("errorWithIdentifier:message:parameters:")]
		YMMError ErrorWithIdentifier (string identifier, [NullAllowed] string message, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// +(instancetype _Nonnull)errorWithIdentifier:(NSString * _Nonnull)identifier message:(NSString * _Nullable)message parameters:(NSDictionary<NSString *,id> * _Nullable)parameters backtrace:(NSArray<NSNumber *> * _Nullable)backtrace underlyingError:(id<YMMErrorRepresentable> _Nullable)underlyingError;
		[Static]
		[Export ("errorWithIdentifier:message:parameters:backtrace:underlyingError:")]
		YMMError ErrorWithIdentifier (string identifier, [NullAllowed] string message, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] NSNumber[] backtrace, [NullAllowed] YMMErrorRepresentable underlyingError);
	}

	// @interface YMMECommerceAmount : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceAmount
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull unit;
		[Export ("unit")]
		string Unit { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull value;
		[Export ("value", ArgumentSemantic.Strong)]
		NSDecimalNumber Value { get; }

		// -(instancetype _Nonnull)initWithUnit:(NSString * _Nonnull)unit value:(NSDecimalNumber * _Nonnull)value;
		[Export ("initWithUnit:value:")]
		IntPtr Constructor (string unit, NSDecimalNumber value);
	}

	// @interface YMMECommercePrice : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommercePrice
	{
		// @property (readonly, nonatomic, strong) YMMECommerceAmount * _Nonnull fiat;
		[Export ("fiat", ArgumentSemantic.Strong)]
		YMMECommerceAmount Fiat { get; }

		// @property (readonly, copy, nonatomic) NSArray<YMMECommerceAmount *> * _Nullable internalComponents;
		[NullAllowed, Export ("internalComponents", ArgumentSemantic.Copy)]
		YMMECommerceAmount[] InternalComponents { get; }

		// -(instancetype _Nonnull)initWithFiat:(YMMECommerceAmount * _Nonnull)fiat;
		[Export ("initWithFiat:")]
		IntPtr Constructor (YMMECommerceAmount fiat);

		// -(instancetype _Nonnull)initWithFiat:(YMMECommerceAmount * _Nonnull)fiat internalComponents:(NSArray<YMMECommerceAmount *> * _Nullable)internalComponents;
		[Export ("initWithFiat:internalComponents:")]
		IntPtr Constructor (YMMECommerceAmount fiat, [NullAllowed] YMMECommerceAmount[] internalComponents);
	}

	// @interface YMMECommerceScreen : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceScreen
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable categoryComponents;
		[NullAllowed, Export ("categoryComponents", ArgumentSemantic.Copy)]
		string[] CategoryComponents { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable searchQuery;
		[NullAllowed, Export ("searchQuery")]
		string SearchQuery { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Payload { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name;
		[Export ("initWithName:")]
		IntPtr Constructor (string name);

		// -(instancetype _Nonnull)initWithCategoryComponents:(NSArray<NSString *> * _Nonnull)categoryComponents;
		[Export ("initWithCategoryComponents:")]
		IntPtr Constructor (string[] categoryComponents);

		//TODO Problem, duplicate constructor with same parametrs, dont know fix this
		// -(instancetype _Nonnull)initWithSearchQuery:(NSString * _Nonnull)searchQuery;
		//[Export("initWithSearchQuery:")]
		//IntPtr Constructor(string searchQuery);

		// -(instancetype _Nonnull)initWithPayload:(NSDictionary<NSString *,NSString *> * _Nonnull)payload;
		[Export ("initWithPayload:")]
		IntPtr Constructor (NSDictionary<NSString, NSString> payload);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nullable)name categoryComponents:(NSArray<NSString *> * _Nullable)categoryComponents searchQuery:(NSString * _Nullable)searchQuery payload:(NSDictionary<NSString *,NSString *> * _Nullable)payload;
		[Export ("initWithName:categoryComponents:searchQuery:payload:")]
		IntPtr Constructor ([NullAllowed] string name, [NullAllowed] string[] categoryComponents, [NullAllowed] string searchQuery, [NullAllowed] NSDictionary<NSString, NSString> payload);
	}

	// @interface YMMECommerceProduct : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceProduct
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull sku;
		[Export ("sku")]
		string Sku { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable categoryComponents;
		[NullAllowed, Export ("categoryComponents", ArgumentSemantic.Copy)]
		string[] CategoryComponents { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Payload { get; }

		// @property (readonly, nonatomic, strong) YMMECommercePrice * _Nullable actualPrice;
		[NullAllowed, Export ("actualPrice", ArgumentSemantic.Strong)]
		YMMECommercePrice ActualPrice { get; }

		// @property (readonly, nonatomic, strong) YMMECommercePrice * _Nullable originalPrice;
		[NullAllowed, Export ("originalPrice", ArgumentSemantic.Strong)]
		YMMECommercePrice OriginalPrice { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable promoCodes;
		[NullAllowed, Export ("promoCodes", ArgumentSemantic.Copy)]
		string[] PromoCodes { get; }

		// -(instancetype _Nonnull)initWithSKU:(NSString * _Nonnull)sku;
		[Export ("initWithSKU:")]
		IntPtr Constructor (string sku);

		// -(instancetype _Nonnull)initWithSKU:(NSString * _Nonnull)sku name:(NSString * _Nullable)name categoryComponents:(NSArray<NSString *> * _Nullable)categoryComponents payload:(NSDictionary<NSString *,NSString *> * _Nullable)payload actualPrice:(YMMECommercePrice * _Nullable)actualPrice originalPrice:(YMMECommercePrice * _Nullable)originalPrice promoCodes:(NSArray<NSString *> * _Nullable)promoCodes;
		[Export ("initWithSKU:name:categoryComponents:payload:actualPrice:originalPrice:promoCodes:")]
		IntPtr Constructor (string sku, [NullAllowed] string name, [NullAllowed] string[] categoryComponents, [NullAllowed] NSDictionary<NSString, NSString> payload, [NullAllowed] YMMECommercePrice actualPrice, [NullAllowed] YMMECommercePrice originalPrice, [NullAllowed] string[] promoCodes);
	}

	// @interface YMMECommerceReferrer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceReferrer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable type;
		[NullAllowed, Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable identifier;
		[NullAllowed, Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic, strong) YMMECommerceScreen * _Nullable screen;
		[NullAllowed, Export ("screen", ArgumentSemantic.Strong)]
		YMMECommerceScreen Screen { get; }

		// -(instancetype _Nonnull)initWithType:(NSString * _Nullable)type identifier:(NSString * _Nullable)identifier screen:(YMMECommerceScreen * _Nullable)screen;
		[Export ("initWithType:identifier:screen:")]
		IntPtr Constructor ([NullAllowed] string type, [NullAllowed] string identifier, [NullAllowed] YMMECommerceScreen screen);
	}

	// @interface YMMECommerceCartItem : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceCartItem
	{
		// @property (readonly, nonatomic, strong) YMMECommerceProduct * _Nonnull product;
		[Export ("product", ArgumentSemantic.Strong)]
		YMMECommerceProduct Product { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull quantity;
		[Export ("quantity", ArgumentSemantic.Strong)]
		NSDecimalNumber Quantity { get; }

		// @property (readonly, nonatomic, strong) YMMECommercePrice * _Nonnull revenue;
		[Export ("revenue", ArgumentSemantic.Strong)]
		YMMECommercePrice Revenue { get; }

		// @property (readonly, nonatomic, strong) YMMECommerceReferrer * _Nullable referrer;
		[NullAllowed, Export ("referrer", ArgumentSemantic.Strong)]
		YMMECommerceReferrer Referrer { get; }

		// -(instancetype _Nonnull)initWithProduct:(YMMECommerceProduct * _Nonnull)product quantity:(NSDecimalNumber * _Nonnull)quantity revenue:(YMMECommercePrice * _Nonnull)revenue referrer:(YMMECommerceReferrer * _Nullable)referrer;
		[Export ("initWithProduct:quantity:revenue:referrer:")]
		IntPtr Constructor (YMMECommerceProduct product, NSDecimalNumber quantity, YMMECommercePrice revenue, [NullAllowed] YMMECommerceReferrer referrer);
	}

	// @interface YMMECommerceOrder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerceOrder
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSArray<YMMECommerceCartItem *> * _Nonnull cartItems;
		[Export ("cartItems", ArgumentSemantic.Copy)]
		YMMECommerceCartItem[] CartItems { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Payload { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier cartItems:(NSArray<YMMECommerceCartItem *> * _Nonnull)cartItems;
		[Export ("initWithIdentifier:cartItems:")]
		IntPtr Constructor (string identifier, YMMECommerceCartItem[] cartItems);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier cartItems:(NSArray<YMMECommerceCartItem *> * _Nonnull)cartItems payload:(NSDictionary<NSString *,NSString *> * _Nullable)payload;
		[Export ("initWithIdentifier:cartItems:payload:")]
		IntPtr Constructor (string identifier, YMMECommerceCartItem[] cartItems, [NullAllowed] NSDictionary<NSString, NSString> payload);
	}

	// @interface YMMECommerce : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMECommerce
	{
		// +(instancetype _Nonnull)showScreenEventWithScreen:(YMMECommerceScreen * _Nonnull)screen __attribute__((swift_name("showScreenEvent(screen:)")));
		[Static]
		[Export ("showScreenEventWithScreen:")]
		YMMECommerce ShowScreenEventWithScreen (YMMECommerceScreen screen);

		// +(instancetype _Nonnull)showProductCardEventWithProduct:(YMMECommerceProduct * _Nonnull)product screen:(YMMECommerceScreen * _Nonnull)screen __attribute__((swift_name("showProductCardEvent(product:screen:)")));
		[Static]
		[Export ("showProductCardEventWithProduct:screen:")]
		YMMECommerce ShowProductCardEventWithProduct (YMMECommerceProduct product, YMMECommerceScreen screen);

		// +(instancetype _Nonnull)showProductDetailsEventWithProduct:(YMMECommerceProduct * _Nonnull)product referrer:(YMMECommerceReferrer * _Nullable)referrer __attribute__((swift_name("showProductDetailsEvent(product:referrer:)")));
		[Static]
		[Export ("showProductDetailsEventWithProduct:referrer:")]
		YMMECommerce ShowProductDetailsEventWithProduct (YMMECommerceProduct product, [NullAllowed] YMMECommerceReferrer referrer);

		// +(instancetype _Nonnull)addCartItemEventWithItem:(YMMECommerceCartItem * _Nonnull)item __attribute__((swift_name("addCartItemEvent(cartItem:)")));
		[Static]
		[Export ("addCartItemEventWithItem:")]
		YMMECommerce AddCartItemEventWithItem (YMMECommerceCartItem item);

		// +(instancetype _Nonnull)removeCartItemEventWithItem:(YMMECommerceCartItem * _Nonnull)item __attribute__((swift_name("removeCartItemEvent(cartItem:)")));
		[Static]
		[Export ("removeCartItemEventWithItem:")]
		YMMECommerce RemoveCartItemEventWithItem (YMMECommerceCartItem item);

		// +(instancetype _Nonnull)beginCheckoutEventWithOrder:(YMMECommerceOrder * _Nonnull)order __attribute__((swift_name("beginCheckoutEvent(order:)")));
		[Static]
		[Export ("beginCheckoutEventWithOrder:")]
		YMMECommerce BeginCheckoutEventWithOrder (YMMECommerceOrder order);

		// +(instancetype _Nonnull)purchaseEventWithOrder:(YMMECommerceOrder * _Nonnull)order __attribute__((swift_name("purchaseEvent(order:)")));
		[Static]
		[Export ("purchaseEventWithOrder:")]
		YMMECommerce PurchaseEventWithOrder (YMMECommerceOrder order);
	}

	// @protocol YMMYandexMetricaPlugins <NSObject>
	[Model, Protocol]
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetricaPlugins
	{
		// @required -(void)reportUnhandledException:(YMMPluginErrorDetails * _Nonnull)errorDetails onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportUnhandledException(exception:onFailure:)")));
		[Abstract]
		[Export ("reportUnhandledException:onFailure:")]
		void ReportUnhandledException (YMMPluginErrorDetails errorDetails, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(YMMPluginErrorDetails * _Nonnull)errorDetails message:(NSString * _Nullable)message onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportError(error:message:onFailure:)")));
		[Abstract]
		[Export ("reportError:message:onFailure:")]
		void ReportError (YMMPluginErrorDetails errorDetails, [NullAllowed] string message, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportErrorWithIdentifier:(NSString * _Nonnull)identifier message:(NSString * _Nullable)message details:(YMMPluginErrorDetails * _Nullable)errorDetails onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure __attribute__((swift_name("reportError(identifier:message:error:onFailure:)")));
		[Abstract]
		[Export ("reportErrorWithIdentifier:message:details:onFailure:")]
		void ReportErrorWithIdentifier (string identifier, [NullAllowed] string message, [NullAllowed] YMMPluginErrorDetails errorDetails, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)handlePluginInitFinished __attribute__((swift_name("handlePluginInitFinished()")));
		[Abstract]
		[Export ("handlePluginInitFinished")]
		void HandlePluginInitFinished ();
	}

	// @interface YMMPluginErrorDetails : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMPluginErrorDetails
	{
		// @property (copy, nonatomic) NSString * _Nullable exceptionClass;
		[NullAllowed, Export ("exceptionClass")]
		string ExceptionClass { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; set; }

		// @property (copy, nonatomic) NSArray<YMMStackTraceElement *> * _Nullable backtrace;
		[NullAllowed, Export ("backtrace", ArgumentSemantic.Copy)]
		YMMStackTraceElement[] Backtrace { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable platform;
		[NullAllowed, Export ("platform")]
		string Platform { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable virtualMachineVersion;
		[NullAllowed, Export ("virtualMachineVersion")]
		string VirtualMachineVersion { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable pluginEnvironment;
		[NullAllowed, Export ("pluginEnvironment", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> PluginEnvironment { get; set; }

		// -(instancetype _Nonnull)initWithExceptionClass:(NSString * _Nullable)exceptionClass message:(NSString * _Nullable)message backtrace:(NSArray<YMMStackTraceElement *> * _Nullable)backtrace platform:(NSString * _Nullable)platform virtualMachineVersion:(NSString * _Nullable)virtualMachineVersion pluginEnvironment:(NSDictionary<NSString *,NSString *> * _Nullable)pluginEnvironment __attribute__((swift_name("init(exceptionClass:message:backtrace:platform:virtualMachineVersion:pluginEnvironment:)")));
		[Export ("initWithExceptionClass:message:backtrace:platform:virtualMachineVersion:pluginEnvironment:")]
		IntPtr Constructor ([NullAllowed] string exceptionClass, [NullAllowed] string message, [NullAllowed] YMMStackTraceElement[] backtrace, [NullAllowed] string platform, [NullAllowed] string virtualMachineVersion, [NullAllowed] NSDictionary<NSString, NSString> pluginEnvironment);
	}

	// @interface YMMStackTraceElement : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMStackTraceElement
	{
		// @property (copy, nonatomic) NSString * _Nullable className;
		[NullAllowed, Export ("className")]
		string ClassName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable fileName;
		[NullAllowed, Export ("fileName")]
		string FileName { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable line;
		[NullAllowed, Export ("line", ArgumentSemantic.Strong)]
		NSNumber Line { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable column;
		[NullAllowed, Export ("column", ArgumentSemantic.Strong)]
		NSNumber Column { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable methodName;
		[NullAllowed, Export ("methodName")]
		string MethodName { get; set; }

		// -(instancetype _Nonnull)initWithClassName:(NSString * _Nullable)className fileName:(NSString * _Nullable)fileName line:(NSNumber * _Nullable)line column:(NSNumber * _Nullable)column methodName:(NSString * _Nullable)methodName __attribute__((swift_name("init(className:fileName:line:column:methodName:)")));
		[Export ("initWithClassName:fileName:line:column:methodName:")]
		IntPtr Constructor ([NullAllowed] string className, [NullAllowed] string fileName, [NullAllowed] NSNumber line, [NullAllowed] NSNumber column, [NullAllowed] string methodName);
	}

	// @interface YMMAdRevenueInfo : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMAdRevenueInfo : INSCopying, INSMutableCopying
	{
		// @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull adRevenue;
		[Export ("adRevenue", ArgumentSemantic.Strong)]
		NSDecimalNumber AdRevenue { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull currency;
		[Export ("currency")]
		string Currency { get; }

		// @property (readonly, assign, nonatomic) YMMAdType adType;
		[Export ("adType", ArgumentSemantic.Assign)]
		YMMAdType AdType { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adNetwork;
		[NullAllowed, Export ("adNetwork")]
		string AdNetwork { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adUnitID;
		[NullAllowed, Export ("adUnitID")]
		string AdUnitID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adUnitName;
		[NullAllowed, Export ("adUnitName")]
		string AdUnitName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adPlacementID;
		[NullAllowed, Export ("adPlacementID")]
		string AdPlacementID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adPlacementName;
		[NullAllowed, Export ("adPlacementName")]
		string AdPlacementName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable precision;
		[NullAllowed, Export ("precision")]
		string Precision { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Payload { get; }

		// -(instancetype _Nonnull)initWithAdRevenue:(NSDecimalNumber * _Nonnull)adRevenue currency:(NSString * _Nonnull)currency;
		[Export ("initWithAdRevenue:currency:")]
		IntPtr Constructor (NSDecimalNumber adRevenue, string currency);
	}

	// @interface YMMMutableAdRevenueInfo : YMMAdRevenueInfo
	[BaseType (typeof(YMMAdRevenueInfo))]
	interface YMMMutableAdRevenueInfo
	{
		// @property (assign, nonatomic) YMMAdType adType;
		[Export ("adType", ArgumentSemantic.Assign)]
		YMMAdType AdType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable adNetwork;
		[NullAllowed, Export ("adNetwork")]
		string AdNetwork { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable adUnitID;
		[NullAllowed, Export ("adUnitID")]
		string AdUnitID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable adUnitName;
		[NullAllowed, Export ("adUnitName")]
		string AdUnitName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable adPlacementID;
		[NullAllowed, Export ("adPlacementID")]
		string AdPlacementID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable adPlacementName;
		[NullAllowed, Export ("adPlacementName")]
		string AdPlacementName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable precision;
		[NullAllowed, Export ("precision")]
		string Precision { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Payload { get; set; }
	}
}
