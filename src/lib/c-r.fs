\ lib/c-r.fs

\ This file is part of Sin Forth.

\ This file adds `cr` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260113.
\ See change log at the end of the file.

\ ==============================================================

require emit.fs    \ `emit`
require literal.fs \ `literal`

get-order get-current

target-definitions

: cr ( -- )
  13 literal emit ;

  \ doc{
  \
  \ cr ( -- ) "c-r"
  \
  \ Transmit a carriage return to the selected output device.
  \
  \ // XXX TODO
  \ // ``cr`` is a deferred word (see `defer`) whose default action
  \ // is `(cr`.
  \
  \ See also: `emit`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
