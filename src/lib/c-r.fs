\ lib/c-r.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
