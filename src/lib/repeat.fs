\ lib/repeat.fs

\ This file is part of Sin Forth.

\ This file adds `repeat` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012121706.
\ See change log at the end of the file.

\ ==============================================================

require again.fs \ `again`
require then.fs  \ `then`

get-order get-current

compiler-definitions

: repeat \ Compilation: ( orig dest -- )
         \ Run-time:    ( -- )
  compiler{ again then } ;

  \ doc{
  \
  \ repeat
  \   Compilation: ( C: orig dest -- )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` to the backward
  \ reference _dest_, usually left by `begin`.  Resolve the
  \ forward reference _orig_, usually left by `while`.
  \
  \ Run-time: Continue execution at the location specified by
  \ _dest_.
  \
  \ See also: `again`, `then`, `until`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.
