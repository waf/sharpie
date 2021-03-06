﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc
{
    //shamelessly stolen from http://stackoverflow.com/questions/8490084/
    public class MessageType
    {
        public const string Join = "JOIN";
        public const string Mode = "MODE";
        public const string Nick = "NICK";
        public const string Notice = "NOTICE";
        public const string Part = "PART";
        public const string Ping = "PING";
        public const string Pong = "PONG";
        public const string PrivateMessage = "PRIVMSG";
        public const string User = "USER";
        public const string RplNone = "0";
        public const string RplWelcome = "001";  // :Welcome to the Internet Relay Network <nickname>
        public const string RplYourHost = "002";  // :Your host is <server>, running version <ver>
        public const string RplCreated = "003";  // :This server was created <datetime>
        public const string RplMyInfo = "004";  // <server> <ver> <usermode> <chanmode>
        public const string RplMap = "005";  // :map
        public const string RplEndOfMap = "007";  // :End of /MAP
        public const string RplMotdStart = "375";  // :- server Message of the Day
        public const string RplMotd = "372";  // :- <info>
        public const string RplMotdAlt = "377";  // :- <info>                                                                        (some)
        public const string RplMotdAlt2 = "378";  // :- <info>                                                                        (some)
        public const string RplMotdEnd = "376";  // :End of /MOTD command.
        public const string RplUModeIs = "221";  // <mode>
        public const string RplUserHost = "302";  // :userhosts
        public const string RplIsOn = "303";  // :nicknames
        public const string RplAway = "301";  // <nick> :away
        public const string RplUnAway = "305";  // :You are no longer marked as being away
        public const string RplNowAway = "306";  // :You have been marked as being away
        public const string RplWhoisHelper = "310";  // <nick> :looks very helpful                                                       DALNET
        public const string RplWhoIsUser = "311";  // <nick> <username> <address> * :<info>
        public const string RplWhoIsServer = "312";  // <nick> <server> :<info>
        public const string RplWhoIsOperator = "313";  // <nick> :is an IRC Operator
        public const string RplWhoIsIdle = "317";  // <nick> <seconds> <signon> :<info>
        public const string RplEndOfWhois = "318";  // <request> :End of /WHOIS list.
        public const string RplWhoIsChannels = "319";  // <nick> :<channels>
        public const string RplWhoWasUser = "314";  // <nick> <username> <address> * :<info>
        public const string RplEndOfWhoWas = "369";  // <request> :End of WHOWAS
        public const string RplWhoReply = "352";  // <channel> <username> <address> <server> <nick> <flags> :<hops> <info>
        public const string RplEndOfWho = "315";  // <request> :End of /WHO list.
        public const string RplUserIPs = "307";  // :userips                                                                         UNDERNET
        public const string RplUserIP = "340";  // <nick> :<nickname>=+<user>@<IP.address>                                          UNDERNET
        public const string RplListStart = "321";  // Channel :Users Name
        public const string RplList = "322";  // <channel> <users> :<topic>
        public const string RplListEnd = "323";  // :End of /LIST
        public const string RplLinks = "364";  // <server> <hub> :<hops> <info>
        public const string RplEndOfLinks = "365";  // <mask> :End of /LINKS list.
        public const string RplUniqOpIs = "325";
        public const string RplChannelModeIs = "324";  // <channel> <mode>
        public const string RplChannelUrl = "328";  // <channel> :url                                                                   DALNET
        public const string RplChannelCreated = "329";  // <channel> <time>
        public const string RplNoTopic = "331";  // <channel> :No topic is set.
        public const string RplTopic = "332";  // <channel> :<topic>
        public const string RplTopicSetBy = "333";  // <channel> <nickname> <time>
        public const string RplNamReply = "353";  // = <channel> :<names>
        public const string RplEndOfNames = "366";  // <channel> :End of /NAMES list.
        public const string RplInviting = "341";  // <nick> <channel>
        public const string RplSummoning = "342";
        public const string RplInviteList = "346";  // <channel> <invite> <nick> <time>                                                 IRCNET
        public const string RplEndOfInviteList = "357";  // <channel> :End of Channel Invite List                                            IRCNET
        public const string RplExceptList = "348";  // <channel> <exception> <nick> <time>                                              IRCNET
        public const string RplEndOfExceptList = "349";  // <channel> :End of Channel Exception List                                         IRCNET
        public const string RplBanList = "367";  // <channel> <ban> <nick> <time>
        public const string RplEndOfBanList = "368";  // <channel> :End of Channel Ban List
        public const string RplVersion = "351";  // <version>.<debug> <server> :<info>
        public const string RplInfo = "371";  // :<info>
        public const string RplEndOfInfo = "374";  // :End of /INFO list.
        public const string RplYoureOper = "381";  // :You are now an IRC Operator
        public const string RplRehashing = "382";  // <file> :Rehashing
        public const string RplYoureService = "383";
        public const string RplTime = "391";  // <server> :<time>
        public const string RplUsersStart = "392";
        public const string RplUsers = "393";
        public const string RplEndOfUsers = "394";
        public const string RplNoUsers = "395";
        public const string RplServList = "234";
        public const string RplServListEnd = "235";
        public const string RplAdminMe = "256";  // :Administrative info about server
        public const string RplAdminLoc1 = "257";  // :<info>
        public const string RplAdminLoc2 = "258";  // :<info>
        public const string RplAdminEMail = "259";  // :<info>
        public const string RplTryAgain = "263";  // :Server load is temporarily too heavy. Please wait a while and try again.
        public const string RplTraceLink = "200";
        public const string RplTraceConnecting = "201";
        public const string RplTraceHandshake = "202";
        public const string RplTraceUnknown = "203";
        public const string RplTraceOperator = "204";
        public const string RplTraceUser = "205";
        public const string RplTraceServer = "206";
        public const string RplTraceService = "207";
        public const string RplTraceNewType = "208";
        public const string RplTraceClass = "209";
        public const string RplTraceReconnect = "210";
        public const string RplTraceLog = "261";
        public const string RplTraceEnd = "262";
        public const string RplStatsLinkInfo = "211";  // <connection> <sendq> <sentmsg> <sentbyte> <recdmsg> <recdbyte> :<open>
        public const string RplStatsCommands = "212";  // <command> <uses> <bytes>
        public const string RplStatsCLine = "213";  // C <address> * <server> <port> <class>
        public const string RplStatsNLine = "214";  // N <address> * <server> <port> <class>
        public const string RplStatsILine = "215";  // I <ipmask> * <hostmask> <port> <class>
        public const string RplStatsKLine = "216";  // k <address> * <username> <details>
        public const string RplStatsPLine = "217";  // P <port> <??> <??>
        public const string RplStatsQLine = "222";  // <mask> :<comment>
        public const string RplStatsELine = "223";  // E <hostmask> * <username> <??> <??>
        public const string RplStatsDLine = "224";  // D <ipmask> * <username> <??> <??>
        public const string RplStatsLLine = "241";  // L <address> * <server> <??> <??>
        public const string RplStatsuLine = "242";  // :Server Up <num> days, <time>
        public const string RplStatsoLine = "243";  // o <mask> <password> <user> <??> <class>
        public const string RplStatsHLine = "244";  // H <address> * <server> <??> <??>
        public const string RplStatsGLine = "247";  // G <address> <timestamp> :<reason>
        public const string RplStatsULine = "248";  // U <host> * <??> <??> <??>
        public const string RplStatsZLine = "249";  // :info
        public const string RplStatsYLine = "218";  // Y <class> <ping> <freq> <maxconnect> <sendq>
        public const string RplEndOfStats = "219";  // <char> :End of /STATS report
        public const string RplStatsUptime = "242";
        public const string RplGLineList = "280";  // <address> <timestamp> <reason>                                                   UNDERNET
        public const string RplEndOfGLineList = "281";  // :End of G-line List                                                              UNDERNET
        public const string RplSilenceList = "271";  // <nick> <mask>                                                                    UNDERNET/DALNET
        public const string RplEndOfSilenceList = "272";  // <nick> :End of Silence List                                                      UNDERNET/DALNET
        public const string RplLUserClient = "251";  // :There are <user> users and <invis> invisible on <serv> servers
        public const string RplLUserOp = "252";  // <num> :operator(s) online
        public const string RplLUserUnknown = "253";  // <num> :unknown connection(s)
        public const string RplLUserChannels = "254";  // <num> :channels formed
        public const string RplLUserMe = "255";  // :I have <user> clients and <serv> servers
        public const string RplLUserLocalUser = "265";  // :Current local users: <curr> Max: <max>
        public const string RplLUserGlobalUser = "266";  // :Current global users: <curr> Max: <max>
        public const string ErrNoSuchNick = "401";  // <nickname> :No such nick
        public const string ErrNoSuchServer = "402";  // <server> :No such server
        public const string ErrNoSuchChannel = "403";  // <channel> :No such channel
        public const string ErrCannotSendToChan = "404";  // <channel> :Cannot send to channel
        public const string ErrTooManyChannels = "405";  // <channel> :You have joined too many channels
        public const string ErrWasNoSuchNick = "406";  // <nickname> :There was no such nickname
        public const string ErrTooManyTargets = "407";  // <target> :Duplicate recipients. No message delivered
        public const string ErrNoColors = "408";  // <nickname> #<channel> :You cannot use colors on this channel. Not sent: <text>   DALNET
        public const string ErrNoOrigin = "409";  // :No origin specified
        public const string ErrNoRecipient = "411";  // :No recipient given (<command>)
        public const string ErrNoTextToSend = "412";  // :No text to send
        public const string ErrNoTopLevel = "413";  // <mask> :No toplevel domain specified
        public const string ErrWildTopLevel = "414";  // <mask> :Wildcard in toplevel Domain
        public const string ErrBadMask = "415";
        public const string ErrTooMuchInfo = "416";  // <command> :Too many lines in the output, restrict your query                     UNDERNET
        public const string ErrUnknownCommand = "421";  // <command> :Unknown command
        public const string ErrNoMotd = "422";  // :MOTD File is missing
        public const string ErrNoAdminInfo = "423";  // <server> :No administrative info available
        public const string ErrFileError = "424";
        public const string ErrNoNicknameGiven = "431";  // :No nickname given
        public const string ErrErroneusNickname = "432";  // <nickname> :Erroneus Nickname
        public const string ErrNickNameInUse = "433";  // <nickname> :Nickname is already in use.
        public const string ErrNickCollision = "436";  // <nickname> :Nickname collision KILL
        public const string ErrUnAvailResource = "437";  // <channel> :Cannot change nickname while banned on channel
        public const string ErrNickTooFast = "438";  // <nick> :Nick change too fast. Please wait <sec> seconds.                         (most)
        public const string ErrTargetTooFast = "439";  // <target> :Target change too fast. Please wait <sec> seconds.                     DALNET/UNDERNET
        public const string ErrUserNotInChannel = "441";  // <nickname> <channel> :They aren't on that channel
        public const string ErrNotOnChannel = "442";  // <channel> :You're not on that channel
        public const string ErrUserOnChannel = "443";  // <nickname> <channel> :is already on channel
        public const string ErrNoLogin = "444";
        public const string ErrSummonDisabled = "445";  // :SUMMON has been disabled
        public const string ErrUsersDisabled = "446";  // :USERS has been disabled
        public const string ErrNotRegistered = "451";  // <command> :Register first.
        public const string ErrNeedMoreParams = "461";  // <command> :Not enough parameters
        public const string ErrAlreadyRegistered = "462";  // :You may not reregister
        public const string ErrNoPermForHost = "463";
        public const string ErrPasswdMistmatch = "464";
        public const string ErrYoureBannedCreep = "465";
        public const string ErrYouWillBeBanned = "466";
        public const string ErrKeySet = "467";  // <channel> :Channel key already set
        public const string ErrServerCanChange = "468";  // <channel> :Only servers can change that mode                                     DALNET
        public const string ErrChannelIsFull = "471";  // <channel> :Cannot join channel (+l)
        public const string ErrUnknownMode = "472";  // <char> :is unknown mode char to me
        public const string ErrInviteOnlyChan = "473";  // <channel> :Cannot join channel (+i)
        public const string ErrBannedFromChan = "474";  // <channel> :Cannot join channel (+b)
        public const string ErrBadChannelKey = "475";  // <channel> :Cannot join channel (+k)
        public const string ErrBadChanMask = "476";
        public const string ErrNickNotRegistered = "477";  // <channel> :You need a registered nick to join that channel.                      DALNET
        public const string ErrBanListFull = "478";  // <channel> <ban> :Channel ban/ignore list is full
        public const string ErrNoPrivileges = "481";  // :Permission Denied- You're not an IRC operator
        public const string ErrChanOPrivsNeeded = "482";  // <channel> :You're not channel operator
        public const string ErrCantKillServer = "483";  // :You cant kill a server!
        public const string ErrRestricted = "484";  // <nick> <channel> :Cannot kill, kick or deop channel service                      UNDERNET
        public const string ErrUniqOPrivsNeeded = "485";  // <channel> :Cannot join channel (reason)
        public const string ErrNoOperHost = "491";  // :No O-lines for your host
        public const string ErrUModeUnknownFlag = "501";  // :Unknown MODE flag
        public const string ErrUsersDontMatch = "502";  // :Cant change mode for other users
        public const string ErrSilenceListFull = "511";  // <mask> :Your silence list is full                                                UNDERNET/DALNET
    }


}
