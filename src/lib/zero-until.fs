\ lib/zero-until.fs

\ This file is part of Sin Forth.

\ This file adds `0until` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261856.
\ See change log at the end of the file.

\ ==============================================================

require backward-resolve.fs \ `<resolve`
require questian-branch.fs  \ `?branch`

get-order get-current

compiler-definitions

: 0until \ Compilation: ( C: dest -- )
         \ Run-time:    ( f -- )
  ?branch compiler{ <resolve } ;

  \ doc{
  \
  \ 0until
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( f -- )

  \
  \ Compilation: Compile a conditional `0branch` to the backward
  \ reference _dest_, usually left by `begin`.
  \
  \ Run-time: If _f_ is not zero, continue execution at the location
  \ specified by _dest_.

  \ // XXX TODO
  \ See also: `while`, `again`, `repeat`, `<resolve`,
  \ `-until`, `+until`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
